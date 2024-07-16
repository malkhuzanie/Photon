using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photon.Models;

namespace Photon.Data.Configuration;

public class InboundPurchaseOrderEntityTypeConfiguration 
 : IEntityTypeConfiguration<InboundPurchaseOrder>
{
  public void Configure(EntityTypeBuilder<InboundPurchaseOrder> builder)
  {
  }
}
