using Photon.Models;

namespace Photon.Data;

public static class DbInitialiser
{
  public static void Initialise(PhotonContext context)
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
    context.Facilities.Add(new Facility { FacilityCode = "FAC1" });
    context.Equipments.Add(new Equipment { Name = "Scanner", Description = "Barcode scanner" });
    context.SaveChanges();
  }
}