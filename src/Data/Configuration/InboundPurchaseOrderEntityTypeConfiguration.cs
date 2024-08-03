using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photon.Models;
using Photon.Models.PurchaseOrder.Inbound;

namespace Photon.Data.Configuration;

public class InboundPurchaseOrderEntityTypeConfiguration 
 : IEntityTypeConfiguration<InboundPurchaseOrder>
{
  public void Configure(EntityTypeBuilder<InboundPurchaseOrder> builder)
  {
  }
}
