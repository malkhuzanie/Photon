using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Photon.Data;
using Photon.Exceptions;
using Photon.Models;
using SelectPdf;

namespace Photon.Services
{
    public class ReportService(PhotonContext _context)
    {
        public async Task<(MemoryStream, string)> GetItemsByFacilityId(int id)
        {

            if (!await _context.RecordExists<Facility>(f => f.Id == id))
                throw new IllegalArgumentException("The facility doesn't exist");

            var facility = await _context.Facilities.AsNoTracking().SingleOrDefaultAsync(f => f.Id == id);
            var facilityName = facility!.FacilityCode;

            var items = await _context.Items.Where(i => i.FacilityId == id).ToListAsync();

            var htmlContent = new StringBuilder();
            htmlContent.Append("<html><head><style>");
            htmlContent.Append("body {font-family: Arial, sans-serif; margin: 20px;}");
            htmlContent.Append(".header {text-align: center; font-size: 24px; margin-bottom: 20px;}");
            htmlContent.Append(".footer {text-align: center; font-size: 12px; position: fixed; bottom: 20px; width: 100%;}");
            htmlContent.Append(".table {width: 100%; border-collapse: collapse; margin-top: 10px;}");
            htmlContent.Append(".table th, .table td {border: 1px solid #ddd; padding: 8px;}");
            htmlContent.Append(".table th {background-color: #4CAF50; color: white; text-align: left;}");
            htmlContent.Append(".table tr:nth-child(even) {background-color: #f2f2f2;}");
            htmlContent.Append(".table tr:hover {background-color: #ddd;}");
            htmlContent.Append("</style></head><body>");
            htmlContent.Append($"<div class=\"header\">Item List for {facilityName} Facility</div>");
            htmlContent.Append("<table class=\"table\">");
            htmlContent.Append("<tr><th>ID</th><th>Name</th><th>Count</th><th>Manufacturer Date</th><th>Expiry Date</th></tr>");

            foreach (var item in items)
            {
                htmlContent.Append("<tr>");
                htmlContent.Append($"<td>{item.Id}</td>");
                htmlContent.Append($"<td>{item.Name}</td>");
                htmlContent.Append($"<td>{item.Count}</td>");
                htmlContent.Append($"<td>{item.ManufacturerDate.ToShortDateString()}</td>");
                htmlContent.Append($"<td>{item.ExpiringDate.ToShortDateString()}</td>");
                htmlContent.Append("</tr>");
            }

            htmlContent.Append("</table>");
            htmlContent.Append("<div class=\"footer\">Page 1</div>");
            htmlContent.Append("</body></html>");

            HtmlToPdf converter = new();
            PdfDocument doc = converter.ConvertHtmlString(htmlContent.ToString());

            var pdfStream = new System.IO.MemoryStream();
            doc.Save(pdfStream);
            doc.Close();

            pdfStream.Position = 0;

            return (pdfStream, $"Items_{facilityName}.pdf");
        }
    }
}
