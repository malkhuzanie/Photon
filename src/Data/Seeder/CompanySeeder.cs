using Microsoft.EntityFrameworkCore;
using Photon.Models;
using Photon.src.Models;

namespace Photon.Data.Seeder;

public class CompanySeeder(PhotonContext context) : ISeeder
{
    public async Task Seed()
    {
        IEnumerable<string> companies = new List<string>
        {
            "Tesla", "Apple", "Amazon", "Google", "Microsoft", "SpaceX", "Samsung", "Toyota"
        };

        foreach (var company in companies)
        {
            await context.Companies.AddIfNotExists(
                new Company { Name = company },
                (c) => c.Name == company
            );
        }

        await context.SaveChangesAsync();
    }
}
