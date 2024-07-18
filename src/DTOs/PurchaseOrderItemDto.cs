namespace Photon.DTOs;

public class PurchaseOrderItemDto
{
  public int ItemId { get; set; }
  public int OrderedQuantity { get; set; }
  public int ShippedQuantity { get; set; }
  public int ReceivedQuantity { get; set; }
}
