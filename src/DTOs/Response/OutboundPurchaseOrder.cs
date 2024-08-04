using Photon.Models;
using Photon.Models.PurchaseOrder;

namespace Photon.DTOs.Response;

public class OutboundPurchaseOrder
{
  public int PoNbr { get; set; }
  public DateTime OrderDate { get; set; }
  public DateTime ShipDate { get; set; }
  public DateTime DeliveryDate { get; set; }
  public DateTime CancelDate { get; set; }
  public Facility? Facility { get; set; }
  public Customer? Customer { get; set; }
  public string? Address { get; set; }
  public PurchaseOrderStatus Status { get; set; }
  public IEnumerable<PurchaseOrderItemResponseDto> Items { get; set; } 
}