using System.ComponentModel;
using System.Runtime.Versioning;
using Microsoft.EntityFrameworkCore;
using Photon.Data.Configuration;
using Photon.Models;
using Photon.Models.PurchaseOrder;
using Photon.Models.PurchaseOrder.Inbound;
using Photon.Models.PurchaseOrder.Outbound;
using Photon.src.Models;

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
          Database={config["DbConfig:Database"]};
          Include Error Detail=true
          """)
      .UseLazyLoadingProxies()
      .UseSnakeCaseNamingConvention()
      .EnableSensitiveDataLogging();
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(
      typeof(PhotonContext).Assembly
    );

    base.OnModelCreating(modelBuilder);
  }
  
  public static PhotonContext Create()
  {
    IConfiguration config = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("appsettings.json", true, true)
      .Build();
      
    var optionsBuilder = new DbContextOptionsBuilder<PhotonContext>();
        
    optionsBuilder
      .UseNpgsql(
        $"""
         User ID={config["DbConfig:UserId"]};
         Host={config["DbConfig:Host"]}; 
         Password={config["DbConfig:Password"]}; 
         Database={config["DbConfig:Database"]};
         Include Error Detail=true
         """)
      .UseLazyLoadingProxies()
      .UseSnakeCaseNamingConvention()
      .EnableSensitiveDataLogging();
        
    return new PhotonContext(optionsBuilder.Options, config);
  }

  public DbSet<Permission> Permissions { get; set; }
  public DbSet<Role> Roles { get; set; }
  public DbSet<Facility> Facilities { get; set; }
  public DbSet<User> Users { get; set; }
  public DbSet<Equipment> Equipments { get; set; }
  public DbSet<Customer> Customers { get; set; }
  public DbSet<Contact> Contacts { get; set; }
  public DbSet<Supplier> Suppliers { get; set; }
  public DbSet<Item> Items { get; set; }
  public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
  public DbSet<ItemPickupStatus> ItemPickupStatus { get; set; }
  public DbSet<InboundPurchaseOrder> InboundPurchaseOrders { get; set; }
  public DbSet<InboundPurchaseOrderStatus> InboundPurchaseOrderStatus { get; set; }
  public DbSet<OutboundPurchaseOrder> OutboundPurchaseOrders { get; set; }
  public DbSet<OutboundPurchaseOrderStatus> OutboundPurchaseOrderStatus { get; set; }
  public DbSet<Material> Materials { get; set; }
  public DbSet<src.Models.Container> Containers { get; set; }
  public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }
  public DbSet<PickList> PickLists { get; set; }
  public DbSet<PutawayType> PutawayTypes { get; set; }
  public DbSet<Company> Companies { get; set; }
  public DbSet<ItemMaster> ItemMasters { get; set; }
  public DbSet<Shipment> Shipments { get; set; }
}
