using Photon.Models;

namespace Photon.Extensions;

public static class ItemExtension
{
  public static void UpdateFrom(this Item item, Item newItem, Action<Item>? modify = null)
  {
    item.Name = newItem.Name;
    item.Count = newItem.Count;
    item.ManufacturerDate = newItem.ManufacturerDate;
    item.ExpiringDate = newItem.ExpiringDate;
    item.FacilityId = newItem.FacilityId;
    item.Facility = newItem.Facility;
    item.ItemMaster = newItem.ItemMaster;
    item.Materials = newItem.Materials;
    modify?.Invoke(item);
  }
}