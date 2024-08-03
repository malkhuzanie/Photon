using Microsoft.EntityFrameworkCore;
using Photon.Data;
using Photon.DTOs;
using Photon.DTOs.Request;
using Photon.Exceptions;
using Photon.Interfaces;
using Photon.Mapping;
using Photon.Models;

namespace Photon.Services;

public class ContactService(PhotonContext context) 
  : IEntityService<Contact, ContactDto>
{
  public async Task<int?> PhoneNumberExists(string phoneNumber)
  {
    return (await context.Contacts
        .FirstOrDefaultAsync(c => c.PhoneNumber == phoneNumber)
      )?.Id;
  }

  public async Task<Contact?> GetById(int id)
  {
    return await context.Contacts
      .AsNoTracking()
      .FirstOrDefaultAsync(c => c.Id == id);
  }

  public async Task<IEnumerable<Contact>> GetAll()
  {
    return await (from c in context.Contacts select c)
      .AsNoTracking()
      .ToListAsync();
  }

  public async Task<Contact> Create(ContactDto _contact)
  {
    var contact = await context.Contacts
      .Where(c => c.PhoneNumber == _contact.PhoneNumber)
      .FirstOrDefaultAsync();
    if (contact != null)
    {
      throw new EntityExistsException("Contact already exists.");
    }
    contact = await _contact.ToContact();
    context.Contacts.Add(contact);
    await context.SaveChangesAsync();
    return contact;
  }

  public Task Update(int id, ContactDto _contact)
  {
    throw new NotImplementedException();
  }

  public async Task<bool> Delete(int id)
  {
    if (await context.Contacts.FindAsync(id) is not { } contact)
    {
      return false;
    }
    context.Contacts.Remove(contact);
    await context.SaveChangesAsync();
    return true;
  }
}