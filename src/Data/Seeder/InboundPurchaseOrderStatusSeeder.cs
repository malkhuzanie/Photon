using Photon.Models;
using Photon.Models.PurchaseOrder.Inbound;

namespace Photon.Data.Seeder;

public class InboundPurchaseOrderStatusSeeder(PhotonContext context)
  : ISeeder
{
  public async Task Seed()
  {
    await context.InboundPurchaseOrderStatus
      .AddRangeIfNotExists(
        (s) => s.Status,
        new InboundPurchaseOrderStatus { Status = "Ordered" },
        new InboundPurchaseOrderStatus { Status = "Received" },
        new InboundPurchaseOrderStatus { Status = "Canceled" }
      );
  }
}