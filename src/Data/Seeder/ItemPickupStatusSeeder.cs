using Photon.Models.PurchaseOrder;

namespace Photon.Data.Seeder;

public class ItemPickupStatusSeeder(PhotonContext context) : ISeeder
{
  public async Task Seed()
  {
    await context.ItemPickupStatus.AddRangeIfNotExists(
      s => s.Status,
      new ItemPickupStatus { Status = "picked-up"},
      new ItemPickupStatus { Status = "not-picked"},
      new ItemPickupStatus { Status = "out-of-stock"}
    );
  }
}