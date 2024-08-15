using Microsoft.EntityFrameworkCore;
using Photon.Data;
using Photon.DTOs;
using Photon.DTOs.Request;
using Photon.Exceptions;
using Photon.Models;
using Photon.src.Models;

namespace Photon.Mapping
{
    public static class ItemMapping
    {
        public static async Task<Item> ToItem(this ItemDto itemDto, PhotonContext context)
        {
            var facility = await context.Facilities.FindAsync(itemDto.FacilityId);
            return new Item
            {
                Name = itemDto.Name,
                Count = itemDto.Count,
                ManufacturerDate = itemDto.ManufacturerDate,
                ExpiringDate = itemDto.ExpiringDate,
                FacilityId = itemDto.FacilityId,
                Facility = facility!,
                ItemMaster = new ItemMaster
                {
                    Barcode = "DefaultBarcode",
                    Description = "DefaultDescription",
                    PhysicalDimension = "DefaultPhysicalDimension",
                    TechnicalSpecification = "DefaultTechnicalSpecification",
                    MinimumOrderSize = 0,
                    TimeToManufacture = "01-01-0001",
                    PurchaseCost = 0,
                    ItemPricing = 0,
                    ShippingCost = 0,
                    Company = null,
                    PutawayType = null,
                }
            };
        }
    }
}
