using Photon.Models.PurchaseOrder;
using Photon.Models.PurchaseOrder.Inbound;
using Photon.src.Models;

using PO = Photon.Models.PurchaseOrder.PurchaseOrder;

namespace Photon.Models;

public class PickListItem
{
  public int PlNbr { get; set; }
 
  public int PoNbr { get; set; }

  public virtual PO? PurchaseOrder { get; set; }
  
  public int ItemId { get; set; }
  
  public virtual ItemPickupStatus? ItemPickupStatus { get; set; }
  
  public virtual PickList? PickList { get; set; }
  
  public virtual required Item Item { get; set; }
  
  public int Quantity { get; set; }
  
  public string? PickLocation { get; set; }
  
  public virtual Container? FromContainer { get; set; }
  
  public virtual Container? ToContainer { get; set; }
  

  public bool FromInboundPurchaseOrder()
  {
    return PurchaseOrder is InboundPurchaseOrder;
  }
  
  public bool FromOutboundPurchaseOrder()
  {
    return PurchaseOrder is InboundPurchaseOrder;
  }
}
