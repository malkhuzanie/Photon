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
  
  public virtual ICollection<Item> Items { get; set; } = [];
  
  [JsonIgnore]
  public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; } = [];
}
