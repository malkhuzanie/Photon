using Photon.Models;

namespace Photon.Data.Seeder;

public class SupplierSeeder(PhotonContext context) : ISeeder
{
  public async Task Seed()
  {
    await context.Suppliers.AddRangeIfNotExists(
      (s) => s.Name,
      new Supplier { Name = "tokyo_dist_c_001" },
      new Supplier { Name = "No Name" },
      new Supplier { Name = "supplier_1" },
      new Supplier { Name = "supplier_2" },
      new Supplier { Name = "damascus_main_dist_center" }
    );
  }
}