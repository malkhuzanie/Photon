using Photon.Data;
using Photon.DTOs;
using Photon.Models;

namespace Photon.Mapping;

public static class CustomerMapping
{
  public static async Task<Customer> ToCustomer(this CustomerDto customer)
  {
    return await Task.Run(() => new Customer
    {
      Name = customer.Name, 
      Contact = new Contact { PhoneNumber = customer.Contact.PhoneNumber }
    });
  }
}
