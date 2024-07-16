namespace Photon.Models;

public class PurchaseOrderDetails
{
  public int PoNbr { get; set; }
  public virtual required Item Item { get; set; }
  public required int OrderedQuantity { get; set; }
  public required int ReceivedQuantity { get; set; }
  public required int ShippedQuantity { get; set; }
}