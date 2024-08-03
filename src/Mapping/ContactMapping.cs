using Photon.DTOs;
using Photon.DTOs.Request;
using Photon.Models;

namespace Photon.Mapping;

public static class ContactMapping
{
  public static async Task<Contact> ToContact(this ContactDto contact)
  {
    return await Task.Run(() => new Contact { PhoneNumber = contact.PhoneNumber });
  }
}