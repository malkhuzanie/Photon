using Microsoft.EntityFrameworkCore;
using Photon.Data;
using Photon.Models;
using Photon.DTOs;
using Photon.Exceptions;

namespace Photon.Mapping;

public static class RoleMapping
{
  public static async Task<Role> ToRole(this RoleDto role, PhotonContext context)
  {
    var permissions = await context.Permissions
      .Where(p => role.Permissions.Contains(p.Id))
      .ToListAsync();

    var validationResult = await Mapper.Validate(
      new ValidationArg("Permissions", permissions)
    );

    if (validationResult.Status == false)
    {
      throw new IllegalArgumentException(validationResult.Msg);
    }

    return new Role { Name = role.Name, Permissions = permissions };
  }
}