using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photon.Models;

namespace Photon.Data.Configuration;

public class PurchaseOrderDetailsEntityTypeConfiguration 
  : IEntityTypeConfiguration<PurchaseOrderDetails>
{
  public void Configure(EntityTypeBuilder<PurchaseOrderDetails> builder)
  {
    builder.HasKey(pod => pod.PoNbr);
  }
}