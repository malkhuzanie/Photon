using Microsoft.EntityFrameworkCore;
using Photon.Models;
using Photon.Data;
using Photon.DTOs;
using Photon.DTOs.Request;
using Photon.Mapping;
using Photon.Exceptions;
using Photon.Extensions;
using Photon.Interfaces;

namespace Photon.Services;

public enum RoleName
{
  Administrator, Supervisor, Receiving, Shipping, MasterDataManagement, OrderManagement
}

public class RoleService(PhotonContext context)
  : IEntityService<Role, RoleDto>
{
  public async Task<Role?> GetRole(RoleName role)
  {
    string roleName = role switch
    {
      RoleName.Administrator => roleName = "ADMINISTRATOR",
      RoleName.Supervisor => roleName = "SUPERVISOR",
      RoleName.Receiving => roleName = "RECEIVING",
      RoleName.Shipping => roleName = "SHIPPING",
      RoleName.MasterDataManagement => roleName = "MASTER DATA MANAGEMENT",
      RoleName.OrderManagement => roleName = "ORDER MANAGEMENT",
      _ => ""
    };
    return await context.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
  }
  
  private async Task<int?> RoleNameExists(string name)
  {
    return (await context
        .Roles
        .FirstOrDefaultAsync(r => r.Name == name)
      )?.Id;
  }

  public async Task<IEnumerable<Role>> GetAll()
  {
    return await context.Roles
      .Include(r => r.Permissions)
      .AsNoTracking()
      .ToListAsync();
  }

  public async Task<Role?> GetById(int id)
  {
    return await context.Roles
      .Include(r => r.Permissions)
      .AsNoTracking()
      .SingleOrDefaultAsync(r => r.Id == id);
  }

  public async Task<Role> Create(RoleDto _role)
  {
    var role = await _role.ToRole(context);
    if (await RoleNameExists(role.Name) != null)
    {
      throw new IllegalArgumentException("An existing role with the same name exists");
    }

    context.Add(role);
    await context.SaveChangesAsync();
    return role;
  }

  public async Task Update(int id, RoleDto _role)
  {
    var role = await context.Roles.FindAsync(id);
    if (role == null)
    {
      throw new NotFoundException("role is not found in the database.");
    }
    role.UpdateFrom(await _role.ToRole(context));
    await context.SaveChangesAsync();
  }

  public async Task<bool> Delete(int id)
  {
    if (await context.Roles.FindAsync(id) is not { } role)
    {
      return false;
    }

    context.Roles.Remove(role);
    await context.SaveChangesAsync();
    return true;
  }
}
