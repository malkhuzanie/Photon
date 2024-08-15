using Microsoft.EntityFrameworkCore;
using Photon.Models;
using Photon.src.Models;

namespace Photon.Data.Seeder;

public class PutawayTypeSeeder(PhotonContext context) : ISeeder
{
    public async Task Seed()
    {
        IEnumerable<string> putawayTypes = new List<string>
        {
            "Standard", "Bulk", "Chilled", "Hazardous", "Oversized", "Fast-moving", "Valuable"
        };

        foreach (var type in putawayTypes)
        {
            await context.PutawayTypes.AddIfNotExists(
                new PutawayType { PutawayTypeCode = type },
                (pt) => pt.PutawayTypeCode == type
            );
        }

        await context.SaveChangesAsync();
    }
}
