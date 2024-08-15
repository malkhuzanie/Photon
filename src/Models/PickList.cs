namespace Photon.Models;

using PO = Photon.Models.PurchaseOrder.PurchaseOrder;

public class PickList
{
  public int PlNbr { get; set; }
  
  public virtual required User User { get; set; }
  
  public virtual ICollection<PickListItem> Items { get; set; } = [];
}