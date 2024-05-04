using Microsoft.EntityFrameworkCore;
using wms.Models;

namespace wms.Data;

public class WmsContext : DbContext
{
  public WmsContext(DbContextOptions<WmsContext> options)
      : base(options)
  {
  }

  public DbSet<Permission> Permissions { get; set; }
  public DbSet<Role> Roles { get; set; }
  public DbSet<RoleRight> RoleRights { get; set; }
}
