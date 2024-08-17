using Photon.Models;

namespace Photon.Data.Seeder;

public class MaterialSeeder(PhotonContext context) : ISeeder
{
  public async Task Seed()
  {
    await context.Materials.AddRangeIfNotExists(
      (m) => m.Name,
      new Material { Name = "Aluminium"},
      new Material { Name = "Glass"},
      new Material { Name = "Metal"},
      new Material { Name = "Copper"},
      new Material { Name = "Plastic"},
      new Material { Name = "Cotton"}
    );
  }
}