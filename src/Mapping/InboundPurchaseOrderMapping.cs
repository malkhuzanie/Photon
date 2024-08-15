using Photon.Data;
using Photon.DTOs.Response;
using Photon.Exceptions;
using Photon.Models.PurchaseOrder;
using Photon.Models.PurchaseOrder.Inbound;
using Serilog;
using RequestDto = Photon.DTOs.Request.InboundPurchaseOrderDto;

namespace Photon.Mapping;

public static class InboundPurchaseOrderMapping
{
  public static async Task<InboundPurchaseOrder> ToInboundPurchaseOrder(
      this RequestDto po, PhotonContext context)
  {
    var facility = await context.Facilities.FindAsync(po.FacilityId);
    var supplier = await context.Suppliers.FindAsync(po.SupplierId);
    var status = await context.InboundPurchaseOrderStatus.FindAsync(po.StatusId);
    
    var vRes = await Mapper.Validate(
      new ValidationArg("Facility", facility),
      new ValidationArg("Supplier", supplier),
      new ValidationArg("Status", status)
    );

    if (!vRes.Status)
    {
      throw new NotFoundException($"{vRes.Msg} doesn't exist");
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
      PoItems = po.Items.Select(item => item.ToPurchaseOrderItem(context).Result).ToList()
    };
  }

  public static InboundPurchaseOrderResponseDto ToInboundPurchaseOrderResponseDto(
    this InboundPurchaseOrder po)
  {
    return new InboundPurchaseOrderResponseDto
    {
      PoNbr = po.PoNbr,
      OrderDate = po.OrderDate,
      ShipDate = po.ShipDate,
      DeliveryDate = po.DeliveryDate,
      CancelDate = po.CancelDate,
      Supplier = po.Supplier,
      Status = po.Status,
      Facility = po.Facility!,
      Items = po.PoItems.Select(item => item.ToPurchaseOrderItemResponseDto())
    };
  }
}
