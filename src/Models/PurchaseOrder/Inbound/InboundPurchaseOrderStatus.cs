
using System.Text.Json.Serialization;

namespace Photon.Models.PurchaseOrder.Inbound;

public class InboundPurchaseOrderStatus : PurchaseOrderStatus
{
  [JsonIgnore]
  public virtual ICollection<InboundPurchaseOrder> InboundPurchaseOrders { get; set; } = [];
}
