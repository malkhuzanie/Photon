using Microsoft.EntityFrameworkCore;
using Photon.Data;
using Photon.DTOs;
using Photon.Exceptions;
using Photon.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using ClosedXML.Excel;


namespace Photon.Services
{
    public class ReportService(PhotonContext context)
    {
        private readonly PhotonContext _context = context;

        public async Task<(MemoryStream, string)> GetItemsByFacilityId(int id)
        {
            var facility = await _context.Facilities.AsNoTracking().SingleOrDefaultAsync(f => f.Id == id)
                          ?? throw new IllegalArgumentException("The facility doesn't exist");

            var items = await _context.Items
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

        public async Task<(MemoryStream, string)> GetUsersByFacilityId(int facilityId)
        {
            var facility = await _context.Facilities.AsNoTracking().SingleOrDefaultAsync(f => f.Id == facilityId)
                          ?? throw new IllegalArgumentException("The facility doesn't exist");

            var users = await _context.Users
                .Where(u => u.Facility.Id == facilityId)
                .Select(u => new UserReportDto
                {
                    Id = u.Id,
                    Username = u.Username,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    HourlyWage = u.HourlyWage,
                    HireDate = u.HireDate,
                    Roles = u.Roles.Select(r => r.Name).ToList()
                })
                .ToListAsync();

            var pdfStream = await ReportServiceUtils.GeneratePdfReportUsersByFacility(facility.FacilityCode, users);

            return (pdfStream, $"Users_{facility.FacilityCode}.pdf");
        }
        public async Task<(MemoryStream, string)> GetItemsByFacilityExcel(int facilityId)
        {
            var facility = await _context.Facilities.AsNoTracking()
                .SingleOrDefaultAsync(f => f.Id == facilityId)
                ?? throw new IllegalArgumentException("The facility doesn't exist");

            var items = await _context.Items
                .Where(i => i.FacilityId == facilityId)
                .Select(i => new ItemReportDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    Count = i.Count,
                    ManufacturerDate = i.ManufacturerDate,
                    ExpiringDate = i.ExpiringDate
                })
                .ToListAsync();

            var excelStream = await ReportServiceUtils.GenerateExcelReportItemsByFacility(items);

            return (excelStream, $"Items_{facility.FacilityCode}.xlsx");
        }
        public async Task<(MemoryStream, string)> GetUsersByFacilityExcel(int facilityId)
        {
            var facility = await _context.Facilities.AsNoTracking()
                .SingleOrDefaultAsync(f => f.Id == facilityId)
                ?? throw new IllegalArgumentException("The facility doesn't exist");

            var users = await _context.Users
                .Where(u => u.Facility.Id == facilityId)
                .Select(u => new UserReportDto
                {
                    Id = u.Id,
                    Username = u.Username,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    HourlyWage = u.HourlyWage,
                    HireDate = u.HireDate
                })
                .ToListAsync();

            var excelStream = await ReportServiceUtils.GenerateExcelReportUsersByFacility(users);

            return (excelStream, $"Users_{facility.FacilityCode}.xlsx");
        }
    }
}
