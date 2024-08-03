using Microsoft.EntityFrameworkCore;
using Photon.Models;

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
  }
}