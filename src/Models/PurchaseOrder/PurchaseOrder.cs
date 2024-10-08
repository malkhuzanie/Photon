using System.Text.Json.Serialization;

namespace Photon.Models.PurchaseOrder;

public class PurchaseOrder
{
  public int PoNbr { get; set; }

  public DateTime OrderDate { get; set; }

  public DateTime ShipDate { get; set; }

  public DateTime DeliveryDate { get; set; }

  public DateTime CancelDate { get; set; }

  public virtual Facility? Facility { get; set; }

  [JsonIgnore] public virtual ICollection<Item> Items { get; set; } = [];

  public virtual ICollection<PurchaseOrderItem> PoItems { get; set; } = [];

  public int OrderedQuantity(int itemId)
  {
    return PoItems.FirstOrDefault(poItem => poItem.ItemId == itemId)?.OrderedQuantity ?? 0;
  }

  public bool IsReady()
  {
    return PoItems.Aggregate(
      true,
      (current, poItem) => current & poItem.ItemPickupStatus?.Status == "picked-up"
    );
  }

  public decimal TotalCost
  {
    get
    {
      return PoItems.Aggregate(
        (decimal)0, 
        (total, poItem) => total + poItem.PackedQuantity * poItem.ItemPrice
      );
    }
  }
}