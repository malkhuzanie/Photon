using Photon.Data;
using Photon.Dto.Request;
using Photon.Exceptions;
using Photon.Interfaces;
using Photon.Mapping;
using Photon.Models;

namespace Photon.Services;

public class PickListItemService(PhotonContext context, ItemPickupStatusService ipsService)
  : IEntityService<PickListItem, PickListItemDto>
{
  public Task<PickListItem?> GetById(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<PickListItem>> GetAll()
  {
    throw new NotImplementedException();
  }

  public async Task<PickListItem> Create(PickListItemDto _plItem)
  {
    if (_plItem is { PickLocation: not null, FromContainerId: not null })
    {
      throw new IllegalArgumentException(
        "At most one of (Pick location, From container) must be set"
      );
    }
    var plItem = await _plItem.ToPickListItem(context);
    plItem.ItemPickupStatus = await ipsService.GetByIdOrDefault(_plItem.ItemPickupStatusId);
    return plItem;
  }

  public Task Update(int id, PickListItemDto arg)
  {
    throw new NotImplementedException();
  }

  public Task<bool> Delete(int id)
  {
    throw new NotImplementedException();
  }
}