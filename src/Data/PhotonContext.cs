using Microsoft.EntityFrameworkCore;
using Photon.Data.Configuration;
using Photon.Models;

namespace Photon.Data;

public class PhotonContext(DbContextOptions<PhotonContext> options, IConfiguration config) 
  : DbContext(options)
{
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder
      .UseNpgsql(
          $"""
          User ID={config["DbConfig:UserId"]};
          Host={config["DbConfig:Host"]}; 
          Password={config["DbConfig:Password"]}; 
          Database={config["DbConfig:Database"]}
          """)
      .UseLazyLoadingProxies()
      .UseSnakeCaseNamingConvention();
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    new UserEntityTypeConfiguration()
      .Configure(modelBuilder.Entity<User>());
    
    base.OnModelCreating(modelBuilder);
  }

  public DbSet<Permission> Permissions { get; set; }
  public DbSet<Role> Roles { get; set; }
  public DbSet<Facility> Facilities { get; set; }
  public DbSet<User> Users { get; set; }
  public DbSet<Equipment> Equipments { get; set; }
  public DbSet<Customer> Customers { get; set; }
  public DbSet<Contact> Contacts { get; set; }
}
