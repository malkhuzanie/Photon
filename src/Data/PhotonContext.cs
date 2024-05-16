using Microsoft.EntityFrameworkCore;
using Photon.Models;

namespace Photon.Data;

public class PhotonContext : DbContext
{
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder
      .UseNpgsql("Host=localhost; Database=wms_temp")
      .UseLazyLoadingProxies()
      .UseSnakeCaseNamingConvention();
  }
  
  public PhotonContext(DbContextOptions<PhotonContext> options)
      : base(options)
  {
  }

  public DbSet<Permission> Permissions { get; set; }
  public DbSet<Role> Roles { get; set; }
  public DbSet<Facility> Facilities { get; set; }
  public DbSet<User> Users { get; set; }
  public DbSet<Equipment> Equipments { get; set; }
}
