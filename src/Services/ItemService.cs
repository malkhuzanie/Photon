using Microsoft.EntityFrameworkCore;
using Photon.Models;
using Photon.Data;
using Photon.DTOs;
using Photon.Mapping;
using Photon.Exceptions;
using Photon.Extensions;
using Photon.Interfaces;
using System.Net.Http.Headers;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Http.HttpResults;
using Photon.DTOs.Request;

namespace Photon.Services
{
    public class ItemService(PhotonContext context)
      : IEntityService<Item, ItemDto>
    {
        public async Task<IEnumerable<Item>> GetAll()
        {
            return await context.Items.Include(i => i.Facility).AsNoTracking().ToListAsync();
        }

        public async Task<Item?> GetById(int id)
        {
            return await context.Items.Include(i => i.Facility).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Item> Create(ItemDto _itemDto)
        {
            if (await context.RecordExists<Item>(i => i.Name == _itemDto.Name))
                throw new EntityExistsException("An existing with with the same name exists");
            if (!await context.RecordExists<Facility>(f => f.Id == _itemDto.FacilityId))
                throw new IllegalArgumentException("The Facility doesn't exist");
            var item = await _itemDto.ToItem(context);
            context.Items.Add(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> Delete(int id)
        {
            var item = await context.Items.FindAsync(id);
            if (item is null)
                return false;
            context.Items.Remove(item);
            await context.SaveChangesAsync();
            return true;
        }


        public async Task Update(int id, ItemDto _itemDto)
        {
            var item = await context.Items.FindAsync(id) ??
                throw new NotFoundException("Item is not found in the database.");
            item.UpdateFrom(await _itemDto.ToItem(context));
            await context.SaveChangesAsync();
        }
        // filtering the Items in a specific periods
        public async Task<IEnumerable<Item>> GetAll(DateOnly? minExpirationDate, DateOnly? maxExpirationDate, string sortField = "Name", bool ascendingSort = true)
        {
            IQueryable<Item> query = context.Items.Include(i => i.Facility);

            if (minExpirationDate.HasValue)
            {
                query = query.Where(i => i.ExpiringDate >= minExpirationDate.Value);
            }

            if (maxExpirationDate.HasValue)
            {
                query = query.Where(i => i.ExpiringDate <= maxExpirationDate.Value);
            }

            switch (sortField)
            {
                case "Name":
                    query = ascendingSort ? query.OrderBy(i => i.Name) : query.OrderByDescending(i => i.Name);
                    break;
                case "ManufacturerDate":
                    query = ascendingSort ? query.OrderBy(i => i.ManufacturerDate) : query.OrderByDescending(i => i.ManufacturerDate);
                    break;
                default:
                    break;
            }

            return await query.ToListAsync();
        }

    }
}
