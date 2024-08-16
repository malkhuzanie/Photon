using Microsoft.AspNetCore.Mvc;
using Photon.Services.ReportServices;

namespace Photon.Controllers.Reports;

[ApiController]
[Route("report/ob_po/")]
public class OutboundPurchaseOrderReportController(
  OutboundPurchaseOrderReportService service)
  : ControllerBase
{
  [HttpGet("{poNbr:int}/pdf")]
  public async Task<IActionResult> GetPurchaseOrderPdf(int poNbr)
  {
    throw new NotImplementedException();
    // var (pdfStream, fileName) = await service.GetPurchaseOrder(poNbr);
    // return File(pdfStream, "application/pdf", fileName);
  }
}