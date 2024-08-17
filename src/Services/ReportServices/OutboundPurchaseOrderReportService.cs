using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Photon.Models.PurchaseOrder;
using Photon.Models.PurchaseOrder.Outbound;
using QuestPDF.Previewer;

namespace Photon.Services.ReportServices
{
  public class OutboundPurchaseOrderReportService(OutboundPurchaseOrderService service)
  {
    private static MemoryStream GeneratePdfReportForPurchaseOrder(
      OutboundPurchaseOrder purchaseOrder)
    {
      var pdfStream = new MemoryStream();
      QuestPDF.Settings.License = LicenseType.Community;

      Document.Create(container =>
      {
        container.Page(page =>
        {
          page.Size(PageSizes.A4);
          page.Margin(2, Unit.Centimetre);
          page.PageColor(Colors.White);
          page.DefaultTextStyle(x => x.FontSize(10));

          page.Header().Element(container => ComposeHeader(container, purchaseOrder));
          page.Content().Element(container => ComposeContent(container, purchaseOrder));
          page.Footer().Element(ComposeFooter);
        });
      }).GeneratePdf(pdfStream);

      pdfStream.Position = 0;
      return pdfStream;
    }

    private static void ComposeHeader(IContainer container, PurchaseOrder purchaseOrder)
    {
      var titleStyle = TextStyle.Default.FontSize(20).SemiBold().Color(Colors.Blue.Medium);

      container.Row(row =>
      {
        row.RelativeItem().Column(column =>
        {
          column.Item().Text($"Purchase Order #{purchaseOrder.PoNbr}").Style(titleStyle);
          column.Item().Text($"Order Date: {purchaseOrder.OrderDate:d}").FontSize(9);
          column.Spacing(2);
          column.Item().Text($"Facility: {purchaseOrder.Facility?.FacilityCode ?? "N/A"}").FontSize(9);
          column.Spacing(4);
        });
        
        // row.ConstantItem(100).Height(50).Placeholder();
      });
    }

    private static void ComposeContent(IContainer container, PurchaseOrder purchaseOrder)
    {
      container.PaddingVertical(10).Column(column =>
      {
        column.Spacing(10);

        column.Item().Element(container => ComposeOrderDetails(container, purchaseOrder));

        if (purchaseOrder is OutboundPurchaseOrder outboundOrder)
        {
          column.Item().Element(container => ComposeOutboundDetails(container, outboundOrder));
        }

        column.Spacing(20);

        column.Item().Element(container => ComposeItemsTable(container, purchaseOrder));
      });
    }

    private static void ComposeOrderDetails(IContainer container, PurchaseOrder purchaseOrder)
    {
      container.ShowEntire().BorderTop(1).BorderBottom(1)
        .Background(Colors.Grey.Lighten4).Padding(10)
        .Column(column =>
        {
          column.Spacing(5);
          column.Item().Text("Order Details").FontSize(12).Bold();
          column.Item().Text($"Order Date: {purchaseOrder.OrderDate:d}");
          column.Item().Text($"Ship Date: {purchaseOrder.ShipDate:d}");
          column.Item().Text($"Delivery Date: {purchaseOrder.DeliveryDate:d}");
          column.Item().Text($"Cancel Date: {purchaseOrder.CancelDate:d}");
          column.Item().Text($"Status: {(purchaseOrder.IsReady() ? "Ready" : "Pending")}");
          column.Item().Text($"Total Cost: ${purchaseOrder.TotalCost:N2}");
        });
    }

    private static void ComposeItemsTable(IContainer container, PurchaseOrder purchaseOrder)
    {
      container.Table(table =>
      {
        table.ColumnsDefinition(columns =>
        {
          columns.RelativeColumn(3);
          columns.RelativeColumn();
          columns.RelativeColumn();
          columns.RelativeColumn();
          columns.RelativeColumn();
          columns.ConstantColumn(10);
          columns.RelativeColumn();
        });

        table.Header(header =>
        {
          header.Cell().Element(CellStyle).Text("Item Name").SemiBold();
          header.Cell().Element(CellStyle).AlignRight().Text("Ordered Qty").SemiBold();
          header.Cell().Element(CellStyle).AlignRight().Text("Packed Qty").SemiBold();
          header.Cell().Element(CellStyle).AlignRight().Text("Shipped Qty").SemiBold();
          header.Cell().Element(CellStyle).AlignRight().Text("Delivered Qty").SemiBold();
          header.Cell().Element(CellStyle).Text("");
          header.Cell().Element(CellStyle).Text("Pickup Status").SemiBold();

          static IContainer CellStyle(IContainer container)
          {
            return container.DefaultTextStyle(x => x.SemiBold())
              .PaddingVertical(5).BorderBottom(1).BorderColor(Colors.Black);
          }
        });

        foreach (var poItem in purchaseOrder.PoItems)
        {
          table.Cell().Element(CellStyle).Text(poItem.Item?.Name ?? "N/A");
          table.Cell().Element(CellStyle).AlignRight().Text(poItem.OrderedQuantity.ToString());
          table.Cell().Element(CellStyle).AlignRight().Text(poItem.PackedQuantity.ToString());
          table.Cell().Element(CellStyle).AlignRight().Text(poItem.ShippedQuantity.ToString());
          table.Cell().Element(CellStyle).AlignRight().Text(poItem.DeliveredQuantity.ToString());
          table.Cell().Element(CellStyle).Text("");
          table.Cell().Element(CellStyle).Text(poItem.ItemPickupStatus?.Status ?? "N/A");
          continue;

          static IContainer CellStyle(IContainer container)
          {
            return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
              .PaddingVertical(5);
          }
        }
      });
    }

    private static void ComposeOutboundDetails(IContainer container, OutboundPurchaseOrder outboundOrder)
    {
      container.ShowEntire()
        .BorderTop(1)
        .BorderBottom(1)
        .Background(Colors.Grey.Lighten4)
        .Padding(10).Column(column =>
        {
          column.Spacing(5);
          column.Item().Text("Customer Information").FontSize(12).Bold();
          column.Item().Text($"Customer: {outboundOrder.Customer.Name}");
          column.Item().Text($"Address: {outboundOrder.Address}");
        });
    }

    private static void ComposeFooter(IContainer container)
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
      return (
        GeneratePdfReportForPurchaseOrder((await service.GetById(id))!)
        , $"OutboundPurchaseOrder_{id}.pdf"
      );
    }
  }
}