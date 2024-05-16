using Microsoft.EntityFrameworkCore;
using Photon.Models;
using Photon.DTOs;
using Photon.Data;

namespace Photon.Mapping;

public static class Mapper
{
  public static async Task<ValidationResult> Validate(params ValidationArg[] args)
  {
    return await Task.Run(() =>
    {
      foreach (var arg in args)
      {
        if (arg.Value == null)
        {
          return new ValidationResult(false, $"{arg.Name} does not exist.");
        }
      }
      return new ValidationResult(true, string.Empty);
    });
  }

  public static async Task<MappingResult<User>> FromDto(this UserDto user, PhotonContext context)
  {
    var facility = await context.Facilities.FindAsync(user.FacilityId);
    var equipment = await context.Equipments.FindAsync(user.EquipmentId);
    var roles = await context.Roles.Where(r => user.Roles.Contains(r.Id)).ToListAsync();

    var validationResult = await Validate(
      new ValidationArg("Facility", facility),
      new ValidationArg("Equipment", equipment),
      new ValidationArg("Roles", roles)
    );
    
    if (validationResult.Status == false)
    {
      return new MappingResult<User>(validationResult.Msg, null);
    }
    
    return await Task.Run(() =>
    {
      return new MappingResult<User>(
        "",
        new User
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
        });
    });
  }
}
