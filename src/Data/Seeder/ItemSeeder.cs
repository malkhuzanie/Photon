using Bogus;
using Microsoft.EntityFrameworkCore;
using Photon.Models;
using Photon.src.Models;
using Serilog;

namespace Photon.Data.Seeder;

public class ItemSeeder(PhotonContext context) : ISeeder
{
  public async Task Seed()
  {
    var fac = new Facility { FacilityCode = "TOKYO_777" };

    IEnumerable<string> items =
    [
      "Chocolate", "Banana", "Coffee", "Nuclear Reactor", "PC Monitor", "Macbook Pro", "Wine", "Radio",
      "Speaker", "Carpet", "Charger", "Lithium Battery",
      "Inverter", "Sun", "Refrigerator", "Air Conditioner"
    ];

    foreach (var item in items)
    {
      await context.Items.AddIfNotExists(
        new Item { Name = item, Count = 7, Facility = fac! },
        (itm) => itm.Name == item
      );
    }

    // await new FacilitySeeder(context).Seed();
    // await new MaterialSeeder(context).Seed();
    // await new CompanySeeder(context).Seed();
    // await new PutawayTypeSeeder(context).Seed();
      
    var facilities = await context.Facilities.ToListAsync();
    var materials = await context.Materials.ToListAsync();
    var companies = await context.Companies.ToListAsync();
    var putawayTypes = await context.PutawayTypes.ToListAsync();

    var rand = new Random();
    var f = new Faker("en");
    for (var i = 0; i < 10; ++i)
    {
      var name = f.Commerce.ProductName();
      await context.Items.AddIfNotExists(
        new Item
        {
          Name = name,
          Count = f.Random.Number(1, 1000),
          ManufacturerDate = DateOnly.FromDateTime(f.Date.Past(2)),
          ExpiringDate = DateOnly.FromDateTime(f.Date.Future(2)),
          Facility = facilities[rand.Next(0, facilities.Count)],
          Materials = materials.OrderBy(m => Guid.NewGuid()).Take(f.Random.Number(1, 3)).ToList(),
          ItemMaster = new ItemMaster
          {
            Company = companies[rand.Next(0, companies.Count)],
            Barcode = f.Commerce.Ean13(),
            Description = f.Commerce.ProductDescription(),
            PhysicalDimension = $"{f.Random.Number(1, 100)}x{f.Random.Number(1, 100)}x{f.Random.Number(1, 100)}",
            TechnicalSpecification = f.Lorem.Sentence(),
            MinimumOrderSize = f.Random.Number(1, 1000),
            TimeToManufacture = $"{f.Random.Number(1, 30)} days",
            PurchaseCost = f.Random.Decimal(10, 1000),
            ItemPricing = f.Random.Decimal(20, 2000),
            ShippingCost = f.Random.Decimal(5, 100),
            PutawayType = putawayTypes[rand.Next(0, putawayTypes.Count)]
          }
        },
        (item) => item.Name == name
      );
    }
  }
}