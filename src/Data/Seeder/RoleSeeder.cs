using Photon.Models;

namespace Photon.Data.Seeder;

public class RoleSeeder(PhotonContext context) : ISeeder
{
  public async Task Seed()
  {
    var roles = new Dictionary<string, string>()
    {
      {"ADMINISTRATOR", "Administration"},
      {"SUPERVISOR", "Supervising"}, {"SHIPPING", "Shipping"},
      {"RECEIVING", "Receiving"}, {"MASTER DATA MANAGEMENT", "Data Entry" },
      {"ORDER MANAGEMENT", "Order Management"}
    };

    foreach (var (name, description) in roles)
    {
      await context.Roles.AddIfNotExists(
        new Role { Name = name, Permissions = {new Permission { Name = description }}},
        r => r.Name == name
      );
    }
  }
}