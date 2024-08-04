using Photon.Models;
using Photon.Models.PurchaseOrder.Inbound;
using Photon.Models.PurchaseOrder.Outbound;

namespace Photon.Data.Seeder;

public class OutboundPurchaseOrderStatusSeeder(PhotonContext context)
  : ISeeder
{
  public async Task Seed()
  {
    await context.OutboundPurchaseOrderStatus
      .AddRangeIfNotExists(
        (s) => s.Status,
        new OutboundPurchaseOrderStatus { Status = "Ordered" },
        new OutboundPurchaseOrderStatus { Status = "Delivered" },
        new OutboundPurchaseOrderStatus { Status = "Canceled" },
        new OutboundPurchaseOrderStatus { Status = "Shipped" }
      );
  }
}