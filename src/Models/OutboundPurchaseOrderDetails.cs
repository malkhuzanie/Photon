namespace Photon.Models;

public class OutboundPurchaseOrderDetails : PurchaseOrderDetails
{
  public virtual required OutboundPurchaseOrder PurchaseOrder { get; set; }
}