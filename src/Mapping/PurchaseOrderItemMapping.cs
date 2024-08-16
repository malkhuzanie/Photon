using Microsoft.EntityFrameworkCore;
using Photon.Data;
using Photon.DTOs.Request;
using Photon.DTOs.Response;
using Photon.Exceptions;
using Photon.Models.PurchaseOrder;
using Serilog;

namespace Photon.Mapping;

public static class PurchaseOrderItemMapping
{
  public static async Task<PurchaseOrderItem> ToPurchaseOrderItem(
    this PurchaseOrderItemDto poItem, PhotonContext context)
  {
    if (await context.Items.FindAsync(poItem.ItemId) is { } item)
    {
      var pickupStatus = await context.ItemPickupStatus
        .FirstOrDefaultAsync(s => s.Id == poItem.ItemPickupStatusId) 
        ?? await context.ItemPickupStatus.FindAsync(1);

      return new PurchaseOrderItem
      {
        ItemId = item.Id,
        OrderedQuantity = poItem.OrderedQuantity,
        ShippedQuantity = poItem.ShippedQuantity,
        DeliveredQuantity = poItem.DeliveredQuantity,
        ItemPickupStatus = pickupStatus
      };
    }

    throw new NotFoundException($"An item with Id: {poItem.ItemId}, doesn't exist");
  }

  public static PurchaseOrderItemResponseDto ToPurchaseOrderItemResponseDto(
    this PurchaseOrderItem poItem)
  {
    return new PurchaseOrderItemResponseDto
    {
      Id = poItem.ItemId,
      Name = poItem.Item?.Name,
      OrderedQuantity = poItem.OrderedQuantity,
      ShippedQuantity = poItem.DeliveredQuantity,
      DeliveredQuantity = poItem.DeliveredQuantity,
      ItemPickupStatus = poItem.ItemPickupStatus
    };
  }
}