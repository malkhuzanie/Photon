using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photon.Models;
using Photon.Models.PurchaseOrder;
using Photon.Models.PurchaseOrder.Outbound;

namespace Photon.Data.Configuration;

public class OutboundPurchaseOrderEntityTypeConfiguration 
  : IEntityTypeConfiguration<OutboundPurchaseOrder>
{
  public void Configure(EntityTypeBuilder<OutboundPurchaseOrder> builder)
  {
  }
}