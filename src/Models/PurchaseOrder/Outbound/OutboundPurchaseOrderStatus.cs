using System.Text.Json.Serialization;

namespace Photon.Models.PurchaseOrder.Outbound;

public class OutboundPurchaseOrderStatus : PurchaseOrderStatus
{
  [JsonIgnore]
  public virtual ICollection<OutboundPurchaseOrder> OutboundPurchaseOrders { get; set; } = [];
}

