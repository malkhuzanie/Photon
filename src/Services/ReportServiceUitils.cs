using Microsoft.EntityFrameworkCore;
using Photon.DTOs;
using QuestPDF.Helpers;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using ClosedXML.Excel;


namespace Photon.Services
{
    public static class ReportServiceUtils
    {

        public static async Task<MemoryStream> GeneratePdfReportItemsByFacility(string facilityName, IEnumerable<ItemReportDto> items)
        {
            QuestPDF.Settings.License = LicenseType.Community;
            var pdfStream = new MemoryStream();
            await Task.Run(() =>
            {
                Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(2, Unit.Centimetre);
                        page.Header().Text($"Item List for {facilityName} Facility").FontSize(20).SemiBold().AlignCenter();

                        page.Content().PaddingVertical(1, Unit.Centimetre).Column(column =>
                            {
                                column.Spacing(5);

                                column.Item().Table(table =>
                                {
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.ConstantColumn(50); // ID column
                                        columns.RelativeColumn(2);  // Name column
                                        columns.ConstantColumn(80); // Count column
                                        columns.RelativeColumn(2);  // Manufacturer Date column
                                        columns.RelativeColumn(2);  // Expiry Date column
                                    });

                                    table.Header(header =>
                                    {
                                        header.Cell().Element(CellStyle).Text("ID");
                                        header.Cell().Element(CellStyle).Text("Name");
                                        header.Cell().Element(CellStyle).Text("Count");
                                        header.Cell().Element(CellStyle).Text("Manufacturer Date");
                                        header.Cell().Element(CellStyle).Text("Expiry Date");

                                        static IContainer CellStyle(IContainer container)
                                        {
                                            return container.DefaultTextStyle(x => x.SemiBold())
                                                             .BorderBottom(1)
                                                             .BorderColor(Colors.Black)
                                                             .PaddingVertical(5)
                                                             .AlignLeft();
                                        }
                                    });

                                    foreach (var item in items)
                                    {
                                        table.Cell().Element(CellStyle).Text(item.Id.ToString());
                                        table.Cell().Element(CellStyle).Text(item.Name);
                                        table.Cell().Element(CellStyle).Text(item.Count.ToString());
                                        table.Cell().Element(CellStyle).Text(item.ManufacturerDate.ToShortDateString());
                                        table.Cell().Element(CellStyle).Text(item.ExpiringDate.ToShortDateString());

                                        static IContainer CellStyle(IContainer container)
                                        {
                                            return container.BorderBottom(1)
                                                             .BorderColor(Colors.Grey.Lighten2)
                                                             .PaddingVertical(5)
                                                             .AlignLeft();
                                        }
                                    }
                                });
                            });

                        page.Footer().AlignCenter().Text(text =>
                        {
                            text.Span("Page ");
                            text.CurrentPageNumber();
                        });
                    });
                })
            .GeneratePdf(pdfStream);
            });

            pdfStream.Position = 0;
            return pdfStream;
        }
        public static async Task<MemoryStream> GeneratePdfReportUsersByFacility(string facilityName, IEnumerable<UserReportDto> users)
        {
            var pdfStream = new MemoryStream();
            QuestPDF.Settings.License = LicenseType.Community;
            await Task.Run(() =>
            {
                Document.Create(container =>
                    {
                        container.Page(page =>
                        {
                            page.Size(PageSizes.A4);
                            page.Margin(2, Unit.Centimetre);

                            page.Header().Text($"User List for {facilityName} Facility")
                                .FontSize(20)
                                .SemiBold()
                                .AlignCenter();

                            page.Content().PaddingVertical(1, Unit.Centimetre).Column(column =>
                            {
                                column.Spacing(5);

                                column.Item().Table(table =>
                                {
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.ConstantColumn(20);  // ID column
                                        columns.RelativeColumn(2);   // Username column
                                        columns.RelativeColumn(2);   // First Name column
                                        columns.RelativeColumn(2);   // Last Name column
                                        columns.RelativeColumn(3);   // Email column
                                        columns.ConstantColumn(40);  // Hourly Wage column
                                        columns.ConstantColumn(100); // Hire Date column
                                        columns.RelativeColumn(3);   // Roles column
                                    });

                                    table.Header(header =>
                                    {
                                        header.Cell().Element(CellStyle).Text("ID");
                                        header.Cell().Element(CellStyle).Text("Username");
                                        header.Cell().Element(CellStyle).Text("First Name");
                                        header.Cell().Element(CellStyle).Text("Last Name");
                                        header.Cell().Element(CellStyle).Text("Email");
                                        header.Cell().Element(CellStyle).Text("Hourly Wage");
                                        header.Cell().Element(CellStyle).Text("Hire Date");
                                        header.Cell().Element(CellStyle).Text("Roles");

                                        static IContainer CellStyle(IContainer container)
                                        {
                                            return container.DefaultTextStyle(x => x.SemiBold())
                                                               .BorderBottom(1)
                                                               .BorderColor(Colors.Black)
                                                               .PaddingVertical(5)
                                                               .AlignLeft();
                                        }
                                    });

                                    foreach (var user in users)
                                    {
                                        table.Cell().Element(CellStyle).Text(user.Id.ToString());
                                        table.Cell().Element(CellStyle).Text(user.Username);
                                        table.Cell().Element(CellStyle).Text(user.FirstName);
                                        table.Cell().Element(CellStyle).Text(user.LastName);
                                        table.Cell().Element(CellStyle).Text(user.Email);
                                        table.Cell().Element(CellStyle).Text($"${user.HourlyWage}");
                                        table.Cell().Element(CellStyle).Text(user.HireDate.ToString("MM/dd/yyyy"));
                                        table.Cell().Element(CellStyle).Text(string.Join(", ", user.Roles));

                                        static IContainer CellStyle(IContainer container)
                                        {
                                            return container.BorderBottom(1)
                                                               .BorderColor(Colors.Grey.Lighten2)
                                                               .PaddingVertical(5)
                                                               .AlignLeft();
                                        }
                                    }
                                });
                            });

                            page.Footer().AlignCenter().Text(text =>
                            {
                                text.Span("Page ");
                                text.CurrentPageNumber();
                                text.Span(" of ");
                                text.TotalPages();
                            });
                        });
                    })
                     .GeneratePdf(pdfStream);
            });

            pdfStream.Position = 0;
            return pdfStream;
        }

        public static async Task<MemoryStream> GenerateExcelReportItemsByFacility(List<ItemReportDto> items)
        {
            return await Task.Run(() =>
            {
                var memoryStream = new MemoryStream();

                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Items Report");

                    worksheet.Cell(1, 1).Value = "ID";
                    worksheet.Cell(1, 2).Value = "Name";
                    worksheet.Cell(1, 3).Value = "Count";
                    worksheet.Cell(1, 4).Value = "Manufacturer Date";
                    worksheet.Cell(1, 5).Value = "Expiry Date";

                    for (int i = 0; i < items.Count; i++)
                    {
                        worksheet.Cell(i + 2, 1).Value = items[i].Id;
                        worksheet.Cell(i + 2, 2).Value = items[i].Name;
                        worksheet.Cell(i + 2, 3).Value = items[i].Count;
                        worksheet.Cell(i + 2, 4).Value = items[i].ManufacturerDate.ToShortDateString();
                        worksheet.Cell(i + 2, 5).Value = items[i].ExpiringDate.ToShortDateString();
                    }

                    worksheet.Columns().AdjustToContents();

                    workbook.SaveAs(memoryStream);
                }

                memoryStream.Position = 0;

                return memoryStream;
            });
        }
        public static async Task<MemoryStream> GenerateExcelReportUsersByFacility(List<UserReportDto> users)
        {
            return await Task.Run(() =>
            {
                var memoryStream = new MemoryStream();

                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Users Report");

                    worksheet.Cell(1, 1).Value = "ID";
                    worksheet.Cell(1, 2).Value = "Username";
                    worksheet.Cell(1, 3).Value = "First Name";
                    worksheet.Cell(1, 4).Value = "Last Name";
                    worksheet.Cell(1, 5).Value = "Email";
                    worksheet.Cell(1, 6).Value = "Hourly Wage";
                    worksheet.Cell(1, 7).Value = "Hire Date";

                    for (int i = 0; i < users.Count; i++)
                    {
                        worksheet.Cell(i + 2, 1).Value = users[i].Id;
                        worksheet.Cell(i + 2, 2).Value = users[i].Username;
                        worksheet.Cell(i + 2, 3).Value = users[i].FirstName;
                        worksheet.Cell(i + 2, 4).Value = users[i].LastName;
                        worksheet.Cell(i + 2, 5).Value = users[i].Email;
                        worksheet.Cell(i + 2, 6).Value = users[i].HourlyWage;
                        worksheet.Cell(i + 2, 7).Value = users[i].HireDate.ToShortDateString();
                    }

                    worksheet.Columns().AdjustToContents();

                    workbook.SaveAs(memoryStream);
                }

                memoryStream.Position = 0; 

                return memoryStream;
            });
        }
    }
}
