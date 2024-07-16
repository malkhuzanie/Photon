using Photon.Models;

namespace Photon.Data;

public static class DbInitialiser
{
  public static void Initialise(PhotonContext context)
  {
    if (!context.Roles.Any()) 
    {
      context.Roles.Add(
        new Role
        {
          Name = "LOGIN",
          Permissions =
          {
            new Permission { Name = "Administrator" }
          }
        }
      );
    }
    if (!context.Facilities.Any())
    {
      context.Facilities.Add(new Facility { FacilityCode = "FAC1" });
    }
    if (!context.Equipments.Any()) 
    {
      context.Equipments.Add(new Equipment { Name = "Scanner", Description = "Barcode scanner" });
    }
    if (!context.Users.Any()) 
    {
      context.Users.Add(new User
      {
        Username = "temp",
        FirstName = "temp",
        LastName = "temp",
        Email = "temp@gmail.com",
        Password = "temp",
        Image = "/home",
        HourlyWage = 0,
        HireDate = new DateOnly(2025, 1, 1),
        Facility = new Facility { FacilityCode = "FAC1" },
        Equipment = new Equipment { Name = "Scanner", Description = "Barcode scanner" },
        Roles = new List<Role>
        {
          new Role
          {
            Name = "SUPERUSER", 
            Permissions = { new Permission { Name = "WRITE" } }
          }
        }
      });
    }
    context.SaveChanges();
  }
}
