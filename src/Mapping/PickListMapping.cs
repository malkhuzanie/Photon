using Photon.Data;
using Photon.DTOs.Request;
using Photon.DTOs.Response;
using Photon.Exceptions;
using Photon.Models;

namespace Photon.Mapping;

public static class PickListMapping
{
  public static async Task<PickList> ToPickList(this PickListDto pl, PhotonContext context)
  {
    var user = await context.Users.FindAsync(pl.UserId);
    if (user == null)
    {
      throw new NotFoundException($"user with id: {pl.UserId}, is not found");
    }
    return new PickList
    {
      User = user!,
      Items = await Task.WhenAll(pl.Items.Select(async i => await i.ToPickListItem(context)))
    };
  }

  public static PickListResponseDto ToPickListResponseDto(this PickList pl)
  {
    return new PickListResponseDto
    {
      PlNbr = pl.PlNbr,
      UserId = pl.User.Id,
      Name = pl.User.FirstName + pl.User.LastName,
      Items = pl.Items.Select(item => new PickListItemResponseDto
      {
        PoNbr = item.PoNbr,
        ItemId = item.Item.Id,
        ItemName = item.Item.Name,
        Quantity = item.Quantity,
        PickLocation = item.PickLocation,
        FromContainer = item.FromContainer,
        ToContainer = item.ToContainer
      })
    };
  }
}