namespace Photon.Models.PurchaseOrder.Outbound;

public class OutboundPurchaseOrderStatus : PurchaseOrderStatus
{
  public virtual ICollection<OutboundPurchaseOrder> OutboundPurchaseOrders { get; set; } = [];
}

