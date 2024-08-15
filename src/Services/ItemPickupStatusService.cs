using Microsoft.EntityFrameworkCore;
using Photon.Data;
using Photon.Models.PurchaseOrder;

namespace Photon.Services;

public class ItemPickupStatusService(PhotonContext context)
{
  private async Task<ItemPickupStatus?> Default()
  {
    return await context.ItemPickupStatus
      .FirstOrDefaultAsync(s => s.Status == "not-picked");
  }
  
  public async Task<ItemPickupStatus?> GetByIdOrDefault(int? id)
  {
    return await context.ItemPickupStatus 
      .FirstOrDefaultAsync(s => s.Id == id) ?? await Default();
  }
}