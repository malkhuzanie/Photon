using Microsoft.EntityFrameworkCore;
using Photon.Data;
using Photon.DTOs;
using Photon.Exceptions;
using Photon.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Photon.Services
{
    public class ReportService(PhotonContext context)
    {
        public async Task<(MemoryStream, string)> GetItemsByFacilityId(int id)
        {
            var facility = await context.Facilities.AsNoTracking().SingleOrDefaultAsync(f => f.Id == id)
                          ?? throw new IllegalArgumentException("The facility doesn't exist");

            var items = await context.Items
                .Where(i => i.FacilityId == id)
                .Select(i => new ItemReportDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    Count = i.Count,
                    ManufacturerDate = i.ManufacturerDate,
                    ExpiringDate = i.ExpiringDate
                })
                .ToListAsync();

            var pdfStream = await ReportServiceUtils.GeneratePdfReportItemsByFacility(facility.FacilityCode, items);

            return (pdfStream, $"Items_{facility.FacilityCode}.pdf");
        }
    }
}
