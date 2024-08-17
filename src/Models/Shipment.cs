using Photon.Models.PurchaseOrder.Inbound;

namespace Photon.Models;

public class Shipment
{
  public int Id { get; set; }
  public virtual ICollection<InboundPurchaseOrder>? PurchaseOrders { get; set; }
}