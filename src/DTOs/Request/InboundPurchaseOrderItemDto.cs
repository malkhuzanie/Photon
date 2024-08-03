namespace Photon.DTOs.Request;

public class InboundPurchaseOrderItemDto
{
  public int ItemId { get; set; }
  public int OrderedQuantity { get; set; }
  public int ReceivedQuantity { get; set; }
}
