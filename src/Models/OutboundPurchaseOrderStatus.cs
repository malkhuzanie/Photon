namespace Photon.Models;

public class OutboundPurchaseOrderStatus : PurchaseOrderStatus
{
  public virtual ICollection<OutboundPurchaseOrder> OutboundPurchaseOrders { get; set; } = [];
}

