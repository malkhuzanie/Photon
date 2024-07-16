namespace Photon.Models;

public class OutboundPurchaseOrder : PurchaseOrder
{
  public required string Address;
  public virtual required Customer Customer { get; set; }
  public virtual required OutboundPurchaseOrderStatus Status { get; set; }
}
