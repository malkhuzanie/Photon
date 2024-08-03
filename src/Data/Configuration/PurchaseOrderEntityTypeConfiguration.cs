using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photon.Models;
using Photon.Models.PurchaseOrder;

namespace Photon.Data.Configuration;

public class PurchaseOrderEntityTypeConfiguration 
 : IEntityTypeConfiguration<PurchaseOrder>
{
  public void Configure(EntityTypeBuilder<PurchaseOrder> builder)
  {
    builder.UseTptMappingStrategy();
    
    builder.HasKey(po => po.PoNbr);

    builder.HasMany(po => po.Items)
      .WithMany(po => po.PurchaseOrders)
      .UsingEntity<PurchaseOrderItem>();
    
    // builder.HasMany(po => po.Items)
    //   .WithOne(po => po.PurchaseOrder)
    //   .HasForeignKey(po => po.PoNbr);
    // builder.HasMany(po => po.Items)
    //   .WithMany(po => po.PurchaseOrders)
    //   .UsingEntity("PurchaseOrderItem");
  }
}
