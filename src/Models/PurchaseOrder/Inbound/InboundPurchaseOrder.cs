namespace Photon.Models.PurchaseOrder.Inbound;

public class InboundPurchaseOrder : PurchaseOrder
{
  public virtual required Supplier Supplier { get; set; }
  public virtual required InboundPurchaseOrderStatus Status { get; set; }
}
