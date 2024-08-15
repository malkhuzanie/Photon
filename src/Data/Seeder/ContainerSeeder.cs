using Photon.src.Models;

namespace Photon.Data.Seeder;

public class ContainerSeeder(PhotonContext context) : ISeeder
{
  public async Task Seed()
  {
    await context.Containers.AddRangeIfNotExists(
      c => c.Name,
      new Container { Name = "C001", Model = "Unknown"},
      new Container { Name = "C002", Model = "Unknown"},
      new Container { Name = "C003", Model = "Unknown"}
    );
  }
}