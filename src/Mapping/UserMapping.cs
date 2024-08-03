using Microsoft.EntityFrameworkCore;
using Photon.Models;
using Photon.DTOs;
using Photon.Data;
using Photon.DTOs.Request;
using Photon.Exceptions;

namespace Photon.Mapping;

public static class UserMapping
{
  public static async Task<User> ToUser(this UserDto user, PhotonContext context)
  {
    var facility = await context.Facilities.FindAsync(user.FacilityId);
    var equipment = await context.Equipments.FindAsync(user.EquipmentId);
    var roles = await context.Roles.Where(r => user.Roles.Contains(r.Id)).ToListAsync();

    var validationResult = await Mapper.Validate(
      new ValidationArg("Facility", facility),
      new ValidationArg("Equipment", equipment),
      new ValidationArg("Roles", roles)
    );

    if (validationResult.Status == false)
    {
      throw new NotFoundException($"{validationResult.Msg} doesn't exists");
    }

    return new User
    {
      Username = user.Username,
      FirstName = user.FirstName,
      LastName = user.LastName,
      Email = user.Email,
      Password = user.Password,
      Image = user.Image,
      HourlyWage = user.HourlyWage,
      HireDate = user.HireDate,
      Facility = facility!,
      Equipment = equipment!,
      Roles = roles
    };
  }
}
