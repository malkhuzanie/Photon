using Microsoft.EntityFrameworkCore;
using Photon.Data;
using Photon.DTOs;
using Photon.Mapping;
using Photon.Exceptions;
using Photon.Extensions;
using Photon.Interfaces;
using Photon.src.Models;
using Photon.srs.Extensions;

namespace Photon.srs.Services
{
    public class ItemMasterService(PhotonContext context) 
        : IEntityService<ItemMaster, ItemMasterDto>
    {
        public async Task<IEnumerable<ItemMaster>> GetAll()
        {
            return await context.ItemMasters
                .Include(im => im.Company)
                .Include(im => im.Facility)
                .Include(im => im.PutawayType)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ItemMaster?> GetById(int id)
        {
            return await context.ItemMasters
                .Include(im => im.Company)
                .Include(im => im.Facility)
                .Include(im => im.PutawayType)
                .AsNoTracking()
                .SingleOrDefaultAsync(im => im.Id == id);
        }

        public async Task<ItemMaster> Create(ItemMasterDto itemMasterDto)
        {
 
            var itemMaster = await itemMasterDto.ToItemMaster(context);
            context.ItemMasters.Add(itemMaster);
            await context.SaveChangesAsync();
            return itemMaster;
        }

        public async Task Update(int id, ItemMasterDto itemMasterDto)
        {
            var itemMaster = await context.ItemMasters.FindAsync(id) ??
                throw new NotFoundException("ItemMaster is not found in the database.");
            itemMaster.UpdateFrom(await itemMasterDto.ToItemMaster(context));
            await context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var itemMaster = await context.ItemMasters.FindAsync(id);
            if (itemMaster is null)
            {
                return false;
            }
            context.ItemMasters.Remove(itemMaster);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
