using Photon.Models;

namespace Photon.Extensions;

public static class SupplierExtension
{
  public static void UpdateFrom(this Supplier supplier, Supplier newSuppler, Action<Supplier>? modify = null)
  {
    supplier.Name = newSuppler.Name;
    supplier.Contact = newSuppler.Contact;
    modify?.Invoke(supplier);
  }
}