using Photon.Models.PurchaseOrder.Inbound;

namespace Photon.Extensions;

public static class InboundPurchaseOrderExtension
{
    public static void UpdateFrom(this InboundPurchaseOrder po, 
        InboundPurchaseOrder newPo,
        Action<InboundPurchaseOrder>? modify = null)
    {
        po.OrderDate = newPo.OrderDate;
        po.ShipDate = newPo.ShipDate;
        po.DeliveryDate = newPo.DeliveryDate;
        po.CancelDate = newPo.CancelDate;
        po.Facility = newPo.Facility;
        po.Supplier = newPo.Supplier;
        po.Status = newPo.Status;
        po.PoItems = newPo.PoItems;
        
        modify?.Invoke(po);
    }
}