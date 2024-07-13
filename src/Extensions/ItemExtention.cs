using Photon.Models;

namespace Photon.Extensions;

public static class ItemExtension
{
  public static void UpdateFrom(this Item item, Item newItem, Action<Item>? modify = null)
  {
    item.Name = newItem.Name;
    item.ManufacturerDate = newItem.ManufacturerDate;
    item.ExpiringDate = newItem.ExpiringDate;
    item.FacilityId = newItem.FacilityId;
    item.Facility = newItem.Facility;
    modify?.Invoke(item);
  }
}