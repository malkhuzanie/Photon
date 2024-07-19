using Photon.Models;

namespace Photon.Data.Seeder;

public class FacilitySeeder(PhotonContext context) : ISeeder
{
  public async Task Seed()
  {
    await context.Facilities.AddRangeIfNotExists(
      f => f.FacilityCode,
      new Facility { FacilityCode = "JAPAN_007" },
      new Facility { FacilityCode = "USA_O37" }
    );
  }
}