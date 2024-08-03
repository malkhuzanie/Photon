namespace Photon.DTOs.Request;

public class InboundPurchaseOrderDto
{
  public DateTime OrderDate { get; set; }
  public DateTime ShipDate { get; set; }
  public DateTime DeliveryDate { get; set; }
  public DateTime CancelDate { get; set; }
  public required int FacilityId { get; set; }
  public required int SupplierId { get; set; }
  public required int StatusId { get; set; }
  public required List<PurchaseOrderItemDto> Items { get; set; }
}
