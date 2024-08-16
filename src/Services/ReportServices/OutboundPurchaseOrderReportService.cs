using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Photon.Models.PurchaseOrder;
using Photon.Models.PurchaseOrder.Inbound;
using Photon.Models;
using System.IO;
using System.Threading.Tasks;

namespace Photon.Services.ReportServices
{
  public class OutboundPurchaseOrderReportService(OutboundPurchaseOrderService service)
  {
    public static async Task<MemoryStream> GeneratePdfReportForPurchaseOrder(
      InboundPurchaseOrder purchaseOrder)
    {
      throw new NotImplementedException();
    }

    public async Task<(MemoryStream, string)> GetPurchaseOrder(int id)
    {
      throw new NotImplementedException();
    }
  }
}