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

namespace Photon.Services
{
    public class SupplierService(PhotonContext context)
      : IEntityService<Supplier, SupplierDto>
    {

        public async Task<bool> RecordExists<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return await context.Set<TEntity>().SingleOrDefaultAsync(predicate) is not null;
        }



        public async Task<IEnumerable<Supplier>> GetAll()
        {
            return await context.Suppliers
              .Include(s => s.Name)
              .AsNoTracking()
              .ToListAsync();
        }

        public async Task<Supplier?> GetById(int id)
        {
            return await context.Suppliers
              .Include(s => s.Name)
              .AsNoTracking()
              .SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Supplier> Create(SupplierDto _supplier)
        {
            if (await RecordExists<Supplier>(s => s.Name == _supplier.Name))
                throw new IllegalArgumentException("An existing Supplier with the same name exists");
            if (await RecordExists<Contact>(c => c.PhoneNumber == _supplier.Contact))
                throw new IllegalArgumentException("An existing Supplier with the same phone number exists");

            var supplier = await _supplier.ToSupplier(context);
            context.Add(supplier);
            await context.SaveChangesAsync();
            return supplier;
        }

        public async Task Update(int id, SupplierDto _supplier)
        {
            var supplier = await context.Suppliers.FindAsync(id) ?? throw new NotFoundException("role is not found in the database.");
            supplier.UpdateFrom(await _supplier.ToSupplier(context));
            await context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var supplier = await context.Suppliers.FindAsync(id);
            if (supplier is null)
            {
                return false;
            }

            context.Suppliers.Remove(supplier);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
