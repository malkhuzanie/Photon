using Photon.Data.Seeder;
using Photon.Models;

namespace Photon.Data;

public static class DbInitialiser
{
  public static void Initialise(PhotonContext context)
  {
    foreach (var t in typeof(PhotonContext).Assembly.GetTypes())
    {
      if (typeof(ISeeder).IsAssignableFrom(t) && !(t.IsInterface))
      {
        ((ISeeder) Activator.CreateInstance(t, context)!).Seed();
      }
    }
    context.SaveChanges();
  }
}
