namespace Photon.Models.PurchaseOrder;

public class PurchaseOrderItem
{
  public int ItemId { get; set; }
  public int PoNbr { get; set; }
  public int OrderedQuantity { get; set; }
  public int ShippedQuantity { get; set; }
  public int ReceivedQuantity { get; set; }
  // public virtual Item? Item { get; set; }
  public virtual PurchaseOrder? PurchaseOrder { get; set; }
}
