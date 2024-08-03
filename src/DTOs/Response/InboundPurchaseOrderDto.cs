using Photon.Models;
using Photon.Models.PurchaseOrder;

namespace Photon.DTOs.Response;

public class InboundPurchaseOrderDto
{
  public int PoNbr { get; set; }
  public DateTime OrderDate { get; set; }
  public DateTime ShipDate { get; set; }
  public DateTime DeliveryDate { get; set; }
  public DateTime CancelDate { get; set; }
  public Facility Facility { get; set; }
  public Supplier Supplier { get; set; }
  public PurchaseOrderStatusDto Status { get; set; }
  public ICollection<PurchaseOrderItem> Items { get; set; } 
}