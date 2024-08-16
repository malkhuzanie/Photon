using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Photon.Models.PurchaseOrder;
using Photon.Models.PurchaseOrder.Inbound;
using Photon.Models;
using System.IO;
using System.Threading.Tasks;
using QuestPDF.Previewer;

namespace Photon.Services.ReportServices
{
  public class InboundPurchaseOrderReportService
  {
    private readonly InboundPurchaseOrderService _service;

    public InboundPurchaseOrderReportService(InboundPurchaseOrderService service)
    {
      _service = service;
    }

    public static async Task<MemoryStream> GeneratePdfReportForPurchaseOrder(
      InboundPurchaseOrder purchaseOrder)
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
            page.Margin(1, Unit.Centimetre);
            page.PageColor(Colors.White);
            page.DefaultTextStyle(x => x.FontSize(9).FontFamily("Arial"));

            page.Header().Element(x => ComposeHeader(x, purchaseOrder));
            page.Content().Element(x => ComposeContent(x, purchaseOrder));
            page.Footer().Element(ComposeFooter);
          });
        }).ShowInPreviewer();
      });

      pdfStream.Position = 0;
      return pdfStream;
    }

    static void ComposeHeader(IContainer container, InboundPurchaseOrder purchaseOrder)
    {
      container.Column(column =>
      {
        column.Item().Row(row =>
        {
          row.RelativeItem().Column(innerColumn =>
          {
            innerColumn.Item().Text("PURCHASE ORDER").FontSize(24).Bold();
            innerColumn.Item().Text($"Order #: {purchaseOrder.PoNbr}").FontSize(14).Bold();
          });

          row.RelativeItem().AlignRight().Text($"Date: {DateTime.Now:d}").FontSize(10);
        });

        column.Item().PaddingTop(5).BorderBottom(2).BorderColor(Colors.Black);
      });
    }

    static void ComposeContent(IContainer container, InboundPurchaseOrder purchaseOrder)
    {
      container.PaddingVertical(20).Column(column =>
      {
        column.Spacing(20);

        column.Item().Row(row =>
        {
          row.RelativeItem().Element(x => ComposeSupplierDetails(x, purchaseOrder.Supplier));
          row.ConstantItem(50);
          row.RelativeItem().Element(x => ComposeFacilityDetails(x, purchaseOrder.Facility));
        });

        column.Item().Element(x => ComposePurchaseOrderDetails(x, purchaseOrder));
        column.Item().Element(x => ComposeItemsTable(x, purchaseOrder));
      });
    }

    static void ComposePurchaseOrderDetails(IContainer container, InboundPurchaseOrder purchaseOrder)
    {
      container.Border(1).BorderColor(Colors.Black).Padding(10)
        .Column(column =>
        {
          column.Spacing(5);
          column.Item().Text("Purchase Order Details").FontSize(12).Bold().Underline();
          column.Item().Text($"Status: {purchaseOrder.Status.Status}");
          column.Item().Text($"Order Date: {purchaseOrder.OrderDate:d}");
          column.Item().Text($"Ship Date: {purchaseOrder.ShipDate:d}");
          column.Item().Text($"Delivery Date: {purchaseOrder.DeliveryDate:d}");
          column.Item().Text($"Cancel Date: {purchaseOrder.CancelDate:d}");
        });
    }

    static void ComposeSupplierDetails(IContainer container, Supplier supplier)
    {
      container.Border(1).BorderColor(Colors.Black).Padding(10).Column(column =>
      {
        column.Spacing(5);
        column.Item().Text("Supplier").FontSize(12).Bold().Underline();
        column.Item().Text(supplier.Name);
        // Add more supplier details as needed
      });
    }

    static void ComposeFacilityDetails(IContainer container, Facility? facility)
    {
      container.Border(1).BorderColor(Colors.Black).Padding(10).Column(column =>
      {
        column.Spacing(5);
        column.Item().Text("Ship To Facility").FontSize(12).Bold().Underline();
        column.Item().Text(facility?.FacilityCode ?? "N/A");
        // Add more facility details as needed
      });
    }

    static void ComposeItemsTable(IContainer container, InboundPurchaseOrder purchaseOrder)
    {
      container.Table(table =>
      {
        table.ColumnsDefinition(columns =>
        {
          columns.ConstantColumn(30); // Item No.
          columns.RelativeColumn(3); // Item Name
          columns.RelativeColumn(); // Ordered Qty
          columns.RelativeColumn(); // Shipped Qty
          columns.RelativeColumn(); // Delivered Qty
          columns.RelativeColumn(); // Pickup Status
        });

        // Add table header
        table.Header(header =>
        {
          header.Cell().Element(CellStyle).Text("#").SemiBold();
          header.Cell().Element(CellStyle).Text("Item Name").SemiBold();
          header.Cell().Element(CellStyle).AlignRight().Text("Ordered").SemiBold();
          header.Cell().Element(CellStyle).AlignRight().Text("Shipped").SemiBold();
          header.Cell().Element(CellStyle).AlignRight().Text("Delivered").SemiBold();
          header.Cell().Element(CellStyle).Text("     " + "Status").SemiBold();

          static IContainer CellStyle(IContainer container)
          {
            return container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(5).BorderBottom(1)
              .BorderColor(Colors.Black);
          }
        });

        // Add table content
        int i = 0;
        foreach (var poItem in purchaseOrder.PoItems)
        {
          table.Cell().Element(CellStyle).Text((++i).ToString());
          table.Cell().Element(CellStyle).Text(poItem.Item?.Name ?? "N/A");
          table.Cell().Element(CellStyle).AlignRight().Text(poItem.OrderedQuantity.ToString());
          table.Cell().Element(CellStyle).AlignRight().Text(poItem.ShippedQuantity.ToString());
          table.Cell().Element(CellStyle).AlignRight().Text(poItem.DeliveredQuantity.ToString());
          table.Cell().Element(CellStyle).Text("     " + poItem.ItemPickupStatus?.Status ?? "N/A");

          static IContainer CellStyle(IContainer container)
          {
            return container.BorderBottom(0.5f).BorderColor(Colors.Black).PaddingVertical(4);
          }
        }
      });
    }

    static void ComposeFooter(IContainer container)
    {
      container.AlignCenter().Text(x =>
      {
        x.Span("Page ");
        x.CurrentPageNumber();
        x.Span(" of ");
        x.TotalPages();
      });
    }

    public async Task<(MemoryStream, string)> GetPurchaseOrder(int id)
    {
      return (await GeneratePdfReportForPurchaseOrder(
          (await _service.GetById(id))!
        ), $"InboundPurchaseOrder_{id}.pdf");
    }
  }
}