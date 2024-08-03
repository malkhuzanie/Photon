using Microsoft.EntityFrameworkCore;
using Photon.Data;
using Photon.DTOs;
using Photon.DTOs.Request;
using Photon.Exceptions;
using Photon.Extensions;
using Photon.Interfaces;
using Photon.Mapping;
using Photon.Models;

namespace Photon.Services;

public class CustomerService(PhotonContext context, ContactService contact_service) 
  : IEntityService<Customer, CustomerDto>
{
  public async Task<Customer?> GetById(int id)
  {
    return await context.Customers
      .Include(c => c.Contact)
      .AsNoTracking()
      .SingleOrDefaultAsync(c => c.Id == id);
  }

  public async Task<IEnumerable<Customer>> GetAll()
  { return await context.Customers
      .Include(c => c.Contact)
      .AsNoTracking()
      .ToListAsync();
  }

  public async Task<Customer> Create(CustomerDto _customer)
  {
    var customer = await context.Customers
      .Where(c => c.Name == _customer.Name)
      .FirstOrDefaultAsync();
    if (customer != null)
    {
      throw new EntityExistsException("Customer already exists.");
    }
    var contact = await contact_service.PhoneNumberExists(_customer.Contact.PhoneNumber);
    if (contact != null)
    {
      throw new EntityExistsException("Contact already exists.");
    }
    customer = await _customer.ToCustomer();
    context.Customers.Add(customer);
    await context.SaveChangesAsync();
    return customer;
  }

  public async Task Update(int id, CustomerDto _customer)
  {
    var customer = await context.Customers
      .Include(c => c.Contact)
      .SingleOrDefaultAsync(c => c.Id == id);
    if (customer == null)
    {
      throw new NotFoundException("Customer is not found.");
    }
    customer.UpdateFrom(await _customer.ToCustomer());
    await context.SaveChangesAsync();
  }

  public async Task<bool> Delete(int id)
  {
    if (await context.Customers.FindAsync(id) is not { } customer)
    {
      return false;
    }
    context.Customers.Remove(customer);
    await context.SaveChangesAsync();
    return true;
  }
}
