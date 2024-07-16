using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photon.Models;

namespace Photon.Data.Configuration;

public class PurchaseOrderEntityTypeConfiguration 
 : IEntityTypeConfiguration<PurchaseOrder>
{
  public void Configure(EntityTypeBuilder<PurchaseOrder> builder)
  {
    builder.HasKey(po => po.PoNbr);
  }
}
