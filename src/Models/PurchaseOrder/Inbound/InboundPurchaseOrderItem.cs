namespace Photon.Models.PurchaseOrder.Inbound;

public class InboundPurchaseOrderItem : PurchaseOrderItem
{
  public virtual InboundPurchaseOrder InboundPurchaseOrder { get; set; }
}