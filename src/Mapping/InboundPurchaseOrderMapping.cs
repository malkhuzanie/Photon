using Photon.Data;
using Photon.DTOs;
using Photon.DTOs.Request;
using Photon.Exceptions;
using Photon.Models;
using Photon.Models.PurchaseOrder;
using Photon.Models.PurchaseOrder.Inbound;

namespace Photon.Mapping;

public static class InboundPurchaseOrderMapping
{
  public static async Task<InboundPurchaseOrder> ToInboundPurchaseOrder(
      this InboundPurchaseOrderDto po, PhotonContext context)
  {
    var facility = await context.Facilities.FindAsync(po.FacilityId);
    var supplier = await context.Suppliers.FindAsync(po.SupplierId);
    var status = await context.InboundPurchaseOrderStatus.FindAsync(po.StatusId);

    Console.WriteLine($"hellllp{status?.Id}");
    
    var vRes = await Mapper.Validate(
      new ValidationArg("Facility", facility),
      new ValidationArg("Supplier", supplier),
      new ValidationArg("Status", status)
    );

    if (!vRes.Status)
    {
      throw new NotFoundException($"{vRes.Msg} doesn't exist");
    }

    IList<PurchaseOrderItem> items = [];
    foreach (var item in po.Items)
    {
      items.Add(await item.ToPurchaseOrderItem(context));
    }

    return new InboundPurchaseOrder
    {
      OrderDate = po.OrderDate,
      ShipDate = po.ShipDate,
      DeliveryDate = po.DeliveryDate,
      CancelDate = po.CancelDate,
      Supplier = supplier!,
      Status = status!,
      Facility = facility!,
      PoItems = items
    };
  }
}
