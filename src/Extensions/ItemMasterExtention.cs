using Photon.Models;
using Photon.src.Models;

namespace Photon.srs.Extensions
{
    public static class ItemMasterExtension
    {
        public static void UpdateFrom(this ItemMaster itemMaster, ItemMaster newItemMaster, Action<ItemMaster>? modify = null)
        {
            itemMaster.Barcode = newItemMaster.Barcode;
            itemMaster.Description = newItemMaster.Description;
            itemMaster.PhysicalDimension = newItemMaster.PhysicalDimension;
            itemMaster.TechnicalSpecification = newItemMaster.TechnicalSpecification;
            itemMaster.MinimumOrderSize = newItemMaster.MinimumOrderSize;
            itemMaster.TimeToManufacture = newItemMaster.TimeToManufacture;
            itemMaster.PurchaseCost = newItemMaster.PurchaseCost;
            itemMaster.ItemPricing = newItemMaster.ItemPricing;
            itemMaster.ShippingCost = newItemMaster.ShippingCost;
            itemMaster.Company = newItemMaster.Company;
            itemMaster.PutawayType = newItemMaster.PutawayType;

            modify?.Invoke(itemMaster);
        }
    }
}
