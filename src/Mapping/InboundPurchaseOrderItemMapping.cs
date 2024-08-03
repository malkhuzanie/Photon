using Photon.Data;
using Photon.DTOs;
using Photon.DTOs.Request;
using Photon.Exceptions;
using Photon.Models;
using Photon.Models.PurchaseOrder;
using Photon.Models.PurchaseOrder.Inbound;

namespace Photon.Mapping;

public static class InboundPurchaseOrderItemMapping
{
  public static async Task<PurchaseOrderItem> ToInboundPurchaseOrderItem(
    this InboundPurchaseOrderItemDto poItem, PhotonContext context)
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