namespace Photon.DTOs;

public class InboundPurchaseOrderDto
{
  public int PoNbr { get; set; }
  public DateTime OrderDate { get; set; }
  public DateTime ShipDate { get; set; }
  public DateTime DeliveryDate { get; set; }
  public DateTime CancelDate { get; set; }
  public required int FacilityId { get; set; }
  public required int SupplierId { get; set; }
  public required int StatusId { get; set; }
  public required List<PurchaseOrderItemDto> Items { get; set; }
}
