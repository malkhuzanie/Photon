using Microsoft.EntityFrameworkCore;
using Photon.Data;
using Photon.DTOs;
using Photon.DTOs.Request;
using Photon.Exceptions;
using Photon.Models;
using Photon.src.Models;

namespace Photon.Mapping
{
    public static class ItemMasterMapping
    {
        public static async Task<ItemMaster> ToItemMaster(this ItemMasterDto itemMasterDto, PhotonContext context)
        {
            var company = await context.Companies
                .FirstOrDefaultAsync(c => c.Id == itemMasterDto.CompanyId);

            if (company == null)
            {
                throw new IllegalArgumentException($"Company with ID {itemMasterDto.CompanyId} not found.");
            }

            var putawayType = await context.PutawayTypes
                .FirstOrDefaultAsync(pt => pt.Id == itemMasterDto.PutawayTypeId);

            if (putawayType == null)
            {
                throw new IllegalArgumentException($"putaway type with ID {itemMasterDto.PutawayTypeId} not found.");

            }

            return new ItemMaster
            {
                Barcode = itemMasterDto.Barcode,
                Description = itemMasterDto.Description,
                PhysicalDimension = itemMasterDto.PhysicalDimension,
                TechnicalSpecification = itemMasterDto.TechnicalSpecification,
                MinimumOrderSize = itemMasterDto.MinimumOrderSize,
                TimeToManufacture = itemMasterDto.TimeToManufacture,
                PurchaseCost = itemMasterDto.PurchaseCost,
                ItemPricing = itemMasterDto.ItemPricing,
                ShippingCost = itemMasterDto.ShippingCost,
                Company = company,
                PutawayType = putawayType
            };
        }
    }
}
