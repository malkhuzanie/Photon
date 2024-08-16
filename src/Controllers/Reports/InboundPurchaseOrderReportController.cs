using Microsoft.AspNetCore.Mvc;
using Photon.Services.ReportServices;

namespace Photon.Controllers.Reports;

[ApiController]
[Route("report/ib_po/")]
public class InboundPurchaseOrderReportController(
  InboundPurchaseOrderReportService service)
  : ControllerBase
{
  [HttpGet("{poNbr:int}/pdf")]
  public async Task<IActionResult> GetPurchaseOrderPdf(int poNbr)
  {
    var (pdfStream, fileName) = await service.GetPurchaseOrder(poNbr);
    return File(pdfStream, "application/pdf", fileName);
  }
}