using Microsoft.EntityFrameworkCore;
using Photon.Data;
using Photon.Models;
using Photon.DTOs;
using Photon.Exceptions;
using Photon.Mapping;
using System.Runtime.CompilerServices;

namespace Photon.Mapping;
public static class SupplierMapping
{
    public static async Task<Supplier> ToSupplier(this SupplierDto supplier, PhotonContext context)
    {
        var validationResult = await Mapper.PhoneNumberValidator(supplier.Contact);

        if (validationResult.Status == false)
        {
            throw new IllegalArgumentException(validationResult.Msg);
        }
        
        return new Supplier { Name = supplier.Name, Contact = new Contact { PhoneNumber = supplier.Contact } };
    }
}