using Photon.Models;
using Photon.Models.PurchaseOrder;

namespace Photon.DTOs.Response;

public class InboundPurchaseOrderResponseDto
{
  public int PoNbr { get; set; }
  public DateTime OrderDate { get; set; }
  public DateTime ShipDate { get; set; }
  public DateTime DeliveryDate { get; set; }
  public DateTime CancelDate { get; set; }
  public Facility? Facility { get; set; }
  public Supplier? Supplier { get; set; }
  public PurchaseOrderStatus? Status { get; set; }
  public IEnumerable<PurchaseOrderItemResponseDto> Items { get; set; } = [];
  public decimal TotalCost { get; set; }
}