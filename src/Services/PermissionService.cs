using Microsoft.EntityFrameworkCore;
using Photon.Data;
using Photon.Models;
using Photon.DTOs;
using Photon.Interfaces;
using Photon.Mapping;

namespace Photon.Services;

public class PermissionService(PhotonContext context)
  : IEntityService<Permission, PermissionDto>
{
  public async Task<IEnumerable<Permission>> GetAll()
  {
    return await context.Permissions.ToListAsync();
  }
  
  public async Task<Permission?> GetById(int id)
  {
    return await (from p in context.Permissions
        where p.Id == id
        select new Permission { Id = p.Id, Name = p.Name }
      ).SingleOrDefaultAsync();
  }

  public async Task<Permission> Create(PermissionDto perm)
  {
    var permission = await perm.ToPermission(context);
    context.Add(permission);
    await context.SaveChangesAsync();
    return permission;
  }

  public Task Update(int id, PermissionDto arg)
  {
    throw new NotImplementedException();
  }

  public async Task<bool> Delete(int id)
  {
    if (await context.Permissions.FindAsync(id) is not { } perm)
    {
      return false;
    }

    context.Permissions.Remove(perm);
    await context.SaveChangesAsync();
    return true;
  }
}
