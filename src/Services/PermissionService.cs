using Microsoft.EntityFrameworkCore;
using Photon.Data;
using Photon.Models;
using Photon.DTOs;
using Photon.Mapping;

namespace Photon.Services;

public class PermissionService(PhotonContext context)
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
    // return await context
    //   .Permissions
    //   .Select (p => new Permission { Id = p.Id, Name = p.Name })
    //   .AsNoTracking()
    //   .SingleOrDefaultAsync(p => p.Id == id);
  }

  public async Task<Permission> Create(PermissionDto perm)
  {
    var permission = await perm.FromDto(context);
    context.Add(permission);
    await context.SaveChangesAsync();
    return permission;
  }
}