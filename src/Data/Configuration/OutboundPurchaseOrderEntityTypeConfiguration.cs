using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photon.Models;

namespace Photon.Data.Configuration;

public class OutboundPurchaseOrderEntityTypeConfiguration 
  : IEntityTypeConfiguration<OutboundPurchaseOrder>
{
  public void Configure(EntityTypeBuilder<OutboundPurchaseOrder> builder)
  {
  }
}