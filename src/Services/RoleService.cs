using Microsoft.EntityFrameworkCore;
using Photon.Models;
using Photon.Data;
using Photon.DTOs;
using Photon.Mapping;
using Photon.Exceptions;

namespace Photon.Services;

public class RoleService(PhotonContext context)
{
  private async Task<Role?> Find(int id)
  {
    return await context.Roles.FirstOrDefaultAsync(r => r.Id == id);
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
    var role = await _role.FromDto(context);
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
    var role = await Find(id);
    if (role == null)
    {
      throw new NotFoundException("role is not found in the database.");
    }

    var newRole = await _role.FromDto(context);
    context.Remove(role);
    context.Add(newRole);
    await context.SaveChangesAsync();
  }

  public async Task<bool> Delete(int id)
  {
    if (await context.Roles.FindAsync(id) is not {} role)
    {
      return false;
    }
    context.Roles.Remove(role);
    await context.SaveChangesAsync();
    return true;
  }
}
