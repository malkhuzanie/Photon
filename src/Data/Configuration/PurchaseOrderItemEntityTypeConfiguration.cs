using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photon.Models;
using Photon.Models.PurchaseOrder;

namespace Photon.Data.Configuration;

public class PurchaseOrderItemEntityTypeConfiguration 
  : IEntityTypeConfiguration<PurchaseOrderItem>
{
  public void Configure(EntityTypeBuilder<PurchaseOrderItem> builder)
  {
    builder.HasKey(poi => new { poi.PoNbr, poi.ItemId });
    // builder.HasOne(poi => poi.PurchaseOrder).WithMany().HasForeignKey(poi => poi.PoNbr);
    builder.UseTpcMappingStrategy();
    
    // builder.HasOne(poi => poi.Item)
    //   .WithMany(poi => poi.PurchaseOrderItems)
    //   .HasForeignKey(poi => poi.ItemId);

    // builder.HasOne(poi => poi.PurchaseOrder)
    //   .WithMany(poi => poi.Items)
    //   .HasForeignKey(poi => poi.PoNbr);
  }
}