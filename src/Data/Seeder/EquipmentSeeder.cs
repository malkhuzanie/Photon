using Photon.Models;

namespace Photon.Data.Seeder;

public class EquipmentSeeder(PhotonContext context) : ISeeder
{
  public async Task Seed()
  {
    await context.Equipments.AddRangeIfNotExists(
      e => e.Name,
      new Equipment { Name = "Tablet", Description = "none" },
      new Equipment { Name = "Barcode Scanner", Description = "Just a barcode scanner" },
      new Equipment { Name = "Printer", Description = "printing machine" },
      new Equipment { Name = "Forklift", Description = "fork truck" },
      new Equipment { Name = "Pallet Jack", Description = "none" }
    );
  }
}