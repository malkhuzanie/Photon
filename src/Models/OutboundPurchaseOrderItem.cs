namespace Photon.Models;

public class OutboundPurchaseOrderItem : PurchaseOrderItem
{
  public virtual required OutboundPurchaseOrder PurchaseOrder { get; set; }
}