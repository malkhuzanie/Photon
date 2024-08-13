using Microsoft.EntityFrameworkCore;
using Photon.DTOs;
using QuestPDF.Helpers;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;


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

    }
}
