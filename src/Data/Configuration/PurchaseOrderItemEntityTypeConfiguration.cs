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
    builder.UseTpcMappingStrategy();
    builder.Ignore(p => p.ItemPrice);
  }
}