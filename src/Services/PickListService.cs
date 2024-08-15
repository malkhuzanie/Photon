using Microsoft.EntityFrameworkCore;
using Photon.Data;
using Photon.DTOs.Request;
using Photon.Exceptions;
using Photon.Extensions;
using Photon.Interfaces;
using Photon.Mapping;
using Photon.Models;

namespace Photon.Services;

public class PickListService(PhotonContext context)
  : IEntityService<PickList, PickListDto>
{
  public async Task<PickList?> GetById(int plNbr)
  {
    return await context.PickLists
      .Include(pl => pl.User)
      .Include(pl => pl.Items)
      .FirstOrDefaultAsync(pl => pl.PlNbr == plNbr);
  }

  public async Task<IEnumerable<PickList>> GetAll()
  {
    return await context.PickLists
      .Include(pl => pl.User)
      .Include(pl => pl.Items)
      .ToListAsync();
  }

  public async Task<PickList> Create(PickListDto pl)
  {
    var user = await context.Users.Include(u => u.Roles)
      .FirstOrDefaultAsync(u => u.Id == pl.UserId);
    
    if (user == null)
    {
      throw new NotFoundException($"User with id: {pl.UserId}, is not found");
    }
    
    if (!user.IsShippingEmployee() && !user.IsReceivingEmployee())
    {
      throw new IllegalArgumentException(
        $"Employee with id: {pl.UserId}, cannot perform ship or receive operations"
      );
    }

    var pickList = new PickList
    {
      User = user,
      Items = pl.Items.Select(i => i.ToPickListItem(context).Result)
        .Select(item =>
        {
          item.Quantity = Math.Min(item.Item.Count, item.PurchaseOrder.OrderedQuantity(item.ItemId));
          return item;
        }).ToList()
    };
    
    context.Add(pickList);
    await context.SaveChangesAsync();
    
    return pickList;
  }

  public Task Update(int id, PickListDto arg)
  {
    throw new NotImplementedException();
  }

  public async Task<bool> Delete(int plNbr)
  {
    if (await context.PickLists.FindAsync(plNbr) is not { } pl)
    {
      return false;
    }
    context.PickLists.Remove(pl);
    await context.SaveChangesAsync();
    return true;
  }
}