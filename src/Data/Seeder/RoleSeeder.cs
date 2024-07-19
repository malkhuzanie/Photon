using Photon.Models;

namespace Photon.Data.Seeder;

public class RoleSeeder(PhotonContext context) : ISeeder
{
  public async Task Seed()
  {
    await context.Roles.AddRangeIfNotExists(
      r => r.Name,
      new Role
      {
        Name = "SUPERVISOR", Permissions = { new Permission { Name = "Supervising" } }
      },
      new Role
      {
        Name = "SHIPPING", Permissions = { new Permission { Name = "Shipping" } }
      },
      new Role
      {
        Name = "RECEIVING", Permissions = { new Permission { Name = "Receiving" } }
      },
      new Role
      {
        Name = "MASTER DATA MANAGEMENT", Permissions = { new Permission { Name = "Data Entry" } }
      },
      new Role
      {
        Name = "ORDER MANAGEMENT", Permissions = { new Permission { Name = "Ordering" } },
      }
    );
  }
}