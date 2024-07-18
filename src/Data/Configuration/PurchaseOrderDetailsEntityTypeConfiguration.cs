using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photon.Models;

namespace Photon.Data.Configuration;

public class PurchaseOrderDetailsEntityTypeConfiguration 
  : IEntityTypeConfiguration<PurchaseOrderItem>
{
  public void Configure(EntityTypeBuilder<PurchaseOrderItem> builder)
  {
    builder.HasKey(pod => pod.PoNbr);
  }
}