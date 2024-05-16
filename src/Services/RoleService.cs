using Microsoft.EntityFrameworkCore;
using Photon.Models;
using Photon.Data;

namespace Photon.Services;

public class RoleService(PhotonContext context) 
{
  public async Task<IEnumerable<Role>> GetAll()
  {
    return await context.Roles
      .Include(r => r.Permissions)
      .AsNoTracking()
      .ToListAsync();
  }
}
