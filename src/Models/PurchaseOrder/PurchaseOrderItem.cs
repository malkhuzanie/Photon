namespace Photon.Models.PurchaseOrder;

public class PurchaseOrderItem
{
  public int ItemId { get; set; }
  
  public int PoNbr { get; set; }
  
  public int OrderedQuantity { get; set; }
  
  public int PackedQuantity { get; set; }
  
  public int ShippedQuantity { get; set; }
  
  public int DeliveredQuantity { get; set; }
  
  public virtual Item? Item { get; set; }
  
  public decimal ItemPrice => Item?.ItemMaster?.ItemPricing ?? 0;
  
  public virtual PurchaseOrder? PurchaseOrder { get; set; }
  
  public virtual ItemPickupStatus? ItemPickupStatus { get; set; }
}
