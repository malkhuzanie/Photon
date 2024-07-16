namespace Photon.Models;

public class InboundPurchaseOrderDetails : PurchaseOrderDetails
{
  public virtual required InboundPurchaseOrder PurchaseOrder { get; set; }
}