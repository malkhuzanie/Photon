namespace Photon.DTOs.Request;

public class PurchaseOrderItemDto
{
  public int ItemId { get; set; }
  public int OrderedQuantity { get; set; }
  public int ReceivedQuantity { get; set; }
}
