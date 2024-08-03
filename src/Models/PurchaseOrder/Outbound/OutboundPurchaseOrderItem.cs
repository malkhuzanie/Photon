namespace Photon.Models.PurchaseOrder.Outbound;

public class OutboundPurchaseOrderItem : PurchaseOrderItem
{
  public virtual required OutboundPurchaseOrder OutboundPurchaseOrder { get; set; }
}