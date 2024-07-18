namespace Photon.Models;

public class InboundPurchaseOrderItem : PurchaseOrderItem
{
  public virtual required InboundPurchaseOrder PurchaseOrder { get; set; }
}