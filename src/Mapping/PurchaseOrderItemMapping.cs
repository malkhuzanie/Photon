using Photon.Data;
using Photon.DTOs.Request;
using Photon.Exceptions;
using Photon.Models.PurchaseOrder;

namespace Photon.Mapping;

public static class PurchaseOrderItemMapping
{
  public static async Task<PurchaseOrderItem> ToPurchaseOrderItem(
    this PurchaseOrderItemDto poItem, PhotonContext context)
  {
    if (await context.Items.FindAsync(poItem.ItemId) is { } item)
    {
      return new PurchaseOrderItem
      {
        ItemId = item.Id,
        OrderedQuantity = poItem.OrderedQuantity,
        ReceivedQuantity = poItem.ReceivedQuantity
      };
    }
    throw new NotFoundException($"An item with Id: {poItem.ItemId}, doesn't exist");
  }
}