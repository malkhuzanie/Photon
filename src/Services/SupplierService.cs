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
using Photon.DTOs.Request;

namespace Photon.Services
{
    public class SupplierService(PhotonContext context)
      : IEntityService<Supplier, SupplierDto>
    {
        public async Task<IEnumerable<Supplier>> GetAll()
        {
            return await context.Suppliers
              .Include(s => s.Contact)
              .AsNoTracking()
              .ToListAsync();
        }

        public async Task<Supplier?> GetById(int id)
        {
            return await context.Suppliers
              .Include(s => s.Contact)
              .AsNoTracking()
              .SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Supplier> Create(SupplierDto _supplier)
        {
            if (await context.RecordExists<Supplier>(s => s.Name == _supplier.Name))
                throw new IllegalArgumentException("An existing Supplier with the same name exists");
            if (await context.RecordExists<Contact>(c => c.PhoneNumber == _supplier.Contact))
                throw new IllegalArgumentException("An existing Supplier with the same phone number exists");

            var supplier = await _supplier.ToSupplier(context);
            context.Suppliers.Add(supplier);
            await context.SaveChangesAsync();
            return supplier;
        }
        
        public async Task Update(int id, SupplierDto _supplier)
        {
            var supplier = await context.Suppliers.FindAsync(id) ??
               throw new NotFoundException("Supplier is not found in the database.");
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
