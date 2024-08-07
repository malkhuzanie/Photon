using Photon.Data;
using Photon.DTOs.Response;
using Photon.Exceptions;
using Photon.Models.PurchaseOrder;
using Photon.Models.PurchaseOrder.Outbound;
using OutboundPurchaseOrder = Photon.DTOs.Response.OutboundPurchaseOrder;

namespace Photon.Mapping;

public static class OutboundPurchaseOrderMapping
{
  public static async Task<Models.PurchaseOrder.Outbound.OutboundPurchaseOrder> ToOutboundPurchaseOrder(
      this OutboundPurchaseOrderDto po, PhotonContext context)
  {
    var facility = await context.Facilities.FindAsync(po.FacilityId);
    var customer = await context.Customers.FindAsync(po.CustomerId);
    var status = await context.OutboundPurchaseOrderStatus.FindAsync(po.StatusId);

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

    return new Models.PurchaseOrder.Outbound.OutboundPurchaseOrder
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

  public static OutboundPurchaseOrder ToOutboundPurchaseOrderResponseDto(
    this Models.PurchaseOrder.Outbound.OutboundPurchaseOrder po)
  {
    return new OutboundPurchaseOrder
    {
      PoNbr = po.PoNbr,
      OrderDate = po.OrderDate,
      ShipDate = po.ShipDate,
      DeliveryDate = po.DeliveryDate,
      CancelDate = po.CancelDate,
      Customer = po.Customer,
      Address = po.Address,
      Status = po.Status,
      Facility = po.Facility!,
      Items = po.PoItems.Select(item => new PurchaseOrderItemResponseDto
      {
        Id = item.ItemId,
        Name = item.Item?.Name,
        OrderedQuantity = item.OrderedQuantity,
        ShippedQuantity = item.DeliveredQuantity,
        DeliveredQuantity = item.DeliveredQuantity
      })
    };
  }
}
