using Photon.Models;
using Photon.src.Models;

namespace Photon.srs.Extensions
{
    public static class ItemMasterExtension
    {
        public static void UpdateFrom(this ItemMaster itemMaster, ItemMaster newItemMaster, Action<ItemMaster>? modify = null)
        {
            itemMaster.ItemNbr = newItemMaster.ItemNbr;
            itemMaster.CompanyId = newItemMaster.CompanyId;
            itemMaster.FacilityId = newItemMaster.FacilityId;
            itemMaster.Barcode = newItemMaster.Barcode;
            itemMaster.Description = newItemMaster.Description;
            itemMaster.PhysicalDimension = newItemMaster.PhysicalDimension;
            itemMaster.TechnicalSpecification = newItemMaster.TechnicalSpecification;
            itemMaster.MinimumOrderSize = newItemMaster.MinimumOrderSize;
            itemMaster.TimeToManufacture = newItemMaster.TimeToManufacture;
            itemMaster.PurchaseCost = newItemMaster.PurchaseCost;
            itemMaster.ItemPricing = newItemMaster.ItemPricing;
            itemMaster.ShippingCost = newItemMaster.ShippingCost;
            itemMaster.PutawayTypeId = newItemMaster.PutawayTypeId;

            modify?.Invoke(itemMaster);
        }
    }
}
