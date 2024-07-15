using Microsoft.EntityFrameworkCore;
using Photon.Data;
using Photon.DTOs;
using Photon.Exceptions;
using Photon.Models;

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
                ManufacturerDate = itemDto.ManufacturerDate,
                ExpiringDate = itemDto.ExpiringDate,
                FacilityId = itemDto.FacilityId,
                Facility = facility!
            };
        }
    }
}