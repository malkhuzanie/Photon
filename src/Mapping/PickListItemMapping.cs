using Microsoft.AspNetCore.Http.HttpResults;
using Photon.Data;
using Photon.Dto.Request;
using Photon.Exceptions;
using Photon.Models;
using Photon.Extensions;

namespace Photon.Mapping;

public static class PickListItemMapping
{
  public static async Task<PickListItem> ToPickListItem(
    this PickListItemDto plItem, PhotonContext context)
  {
    var po = await context.PurchaseOrders.FindAsync(plItem.PoNbr);
    var item = await context.Items.FindAsync(plItem.ItemId);
    var fromContainer = await context.Containers.FindAsync(plItem.FromContainerId);
    var toContainer = await context.Containers.FindAsync(plItem.ToContainerId);

    var vRes = await Mapper.Validate(
      new ValidationArg("Purchase Order", po),
      new ValidationArg("Item", item)
    );

    if (!vRes.Status)
    {
      throw new NotFoundException($"{vRes.Msg} is not found");
    }

    return new PickListItem
    {
      PoNbr = po!.PoNbr,
      Item = item!,
      PickLocation = plItem.PickLocation,
      FromContainer = fromContainer,
      ToContainer = toContainer
    };
  }
}