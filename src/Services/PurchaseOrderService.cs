using Photon.Data;
using Photon.Models;
using Photon.Models.PurchaseOrder;

namespace Photon.Services;

public class PurchaseOrderService(PhotonContext context)
{
  public void CheckIfPurchaseOrderIsReady(PurchaseOrder po)
  {
    if (po.IsReady())
    {
      po.PoItems.ToList().ForEach(poItem =>
      {
        poItem.Item!.Count -= poItem.PackedQuantity;
      });
    }
  }
  
  public void UpdateItemPickupStatus(
    PurchaseOrder po,
    Item item,
    ItemPickupStatus itemPickupStatus)
  {
    var poItem = po.PoItems.FirstOrDefault(poi => poi.Item == item);

    if (poItem == null)
    {
      return;
    }

    if (poItem.ItemPickupStatus?.Status != itemPickupStatus.Status)
    {
      poItem.ItemPickupStatus = itemPickupStatus;
    }
  }
}