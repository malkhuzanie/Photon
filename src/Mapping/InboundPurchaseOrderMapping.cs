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
      this InboundPurchaseOrderDto ipo, PhotonContext context)
  {
    var facility = await context.Facilities.FindAsync(ipo.FacilityId);
    var supplier = await context.Suppliers.FindAsync(ipo.SupplierId);
    var status = await context.InboundPurchaseOrderStatus.FindAsync(ipo.StatusId);

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
    foreach (var item in ipo.Items)
    {
      items.Add(await item.ToInboundPurchaseOrderItem(context));
    }

    return new InboundPurchaseOrder
    {
      Supplier = supplier!,
      Status = status!,
      Facility = facility!,
      PurchaseOrderItems = items
    };
  }
}
