using Photon.Data;
using Photon.Exceptions;
using Photon.Models.PurchaseOrder;
using Photon.Models.PurchaseOrder.Outbound;

namespace Photon.Mapping;

public static class OutboundPurchaseOrderMapping
{
  public static async Task<OutboundPurchaseOrder> ToOutboundPurchaseOrder(
      this OutboundPurchaseOrderDto po, PhotonContext context)
  {
    var facility = await context.Facilities.FindAsync(po.FacilityId);
    var customer = await context.Customers.FindAsync(po.CustomerId);
    var status = await context.OutboundPurchaseOrderStatus.FindAsync(po.StatusId);

    Console.WriteLine($"hellllp{status?.Id}");
    
    var vRes = await Mapper.Validate(
      new ValidationArg("Facility", facility),
      new ValidationArg("Customer", customer),
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

    return new OutboundPurchaseOrder
    {
      OrderDate = po.OrderDate,
      ShipDate = po.ShipDate,
      DeliveryDate = po.DeliveryDate,
      CancelDate = po.CancelDate,
      Status = status!,
      Facility = facility!,
      Customer = customer!,
      Address = po.Address,
      PoItems = items
    };
  }
}
