using Photon.Models;

namespace Photon.Data.Seeder;

public class UserSeeder(PhotonContext context) : ISeeder
{
  public async Task Seed()
  {
    await context.Users.AddRangeIfNotExists(
      u => u.Username,
      new User
      {
        Username = "admin",
        FirstName = "No",
        LastName = "Name",
        Email = "admin@photon.com",
        Password = "admin",
        Image = "/home",
        HourlyWage = 0,
        HireDate = new DateOnly(2025, 1, 1),
        Facility = new Facility { FacilityCode = "DAMASCUS_001" },
        Roles = new List<Role>
        {
          new Role
          {
            Name = "ADMINISTRATOR",
            Permissions = { new Permission { Name = "WRITE" } }
          }
        }
      },
      new User
      {
        Username = "employee",
        FirstName = "I don't have a ",
        LastName = "name too",
        Email = "employee@photon.com",
        Password = "employee",
        Image = "/home",
        HourlyWage = 0,
        HireDate = new DateOnly(2025, 1, 1),
        Facility = new Facility { FacilityCode = "DAMASCUS_001" },
        Equipment = new Equipment { Name = "Tape", Description = "none" },
        Roles = new List<Role>
        {
          new Role
          {
            Name = "EMPLOYEE",
            Permissions = { new Permission { Name = "LOGIN" } }
          }
        }
      }
    );
  }
}