using Photon.Models.PurchaseOrder.Inbound;
using Photon.Models.PurchaseOrder.Outbound;

namespace Photon.Extensions;

public static class OutboundPurchaseOrderExtension
{
    public static void UpdateFrom(this OutboundPurchaseOrder po, 
        OutboundPurchaseOrder newPo,
        Action<OutboundPurchaseOrder>? modify = null)
    {
        po.OrderDate = newPo.OrderDate;
        po.ShipDate = newPo.ShipDate;
        po.DeliveryDate = newPo.DeliveryDate;
        po.CancelDate = newPo.CancelDate;
        po.Facility = newPo.Facility;
        po.Customer = newPo.Customer;
        po.Address = newPo.Address;
        po.Status = newPo.Status;
        po.PoItems = newPo.PoItems;
        
        modify?.Invoke(po);
    }
}
