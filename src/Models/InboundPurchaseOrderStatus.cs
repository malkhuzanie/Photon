
namespace Photon.Models;

public class InboundPurchaseOrderStatus : PurchaseOrderStatus
{
  public virtual ICollection<InboundPurchaseOrder> InboundPurchaseOrders { get; set; } = [];
}
