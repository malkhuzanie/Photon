using Photon.Models;

namespace Photon.Data.Seeder;

public class CustomerSeeder(PhotonContext context) : ISeeder
{
    public async Task Seed()
    {
        await context.Customers.AddRangeIfNotExists(
            c => c.Name,
            new Customer { Name = "David", Contact = new Contact {PhoneNumber = "0947690888" } },
            new Customer { Name = "Elton", Contact = new Contact {PhoneNumber = "0948590888" } },
            new Customer { Name = "Elvis", Contact = new Contact {PhoneNumber = "0949490888" } }
        );
    }
}