using Photon.Models;

namespace Photon.Extensions;

public static class CustomerExtension
{
  public static void UpdateFrom(this Customer customer, Customer _customer, 
    Action<Customer>? modify = null)
  {
    customer.Name = _customer.Name;
    customer.Contact = _customer.Contact;
    modify?.Invoke(customer);
  }
}