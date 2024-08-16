using Microsoft.AspNetCore.Mvc;
using Photon.Services;
using Photon.Services.ReportServices;

namespace Photon.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ReportController(
    ReportService service,
    InboundPurchaseOrderReportService ibPoService)
    : ControllerBase
  {
    [HttpGet("facility/{facilityId:int}/items/pdf")]
    public async Task<IActionResult> GetItemsPdf(int facilityId)
    {
      try
      {
        var (pdfStream, fileName) = await service.GetItemsByFacilityId(facilityId);
        return File(pdfStream, "application/pdf", fileName);
      }
      catch (Exception ex)
      {
        return BadRequest(new { Message = ex.Message });
      }
    }

    [HttpGet("facility/{facilityId:int}/users/pdf")]
    public async Task<IActionResult> GetUsersPdf(int facilityId)
    {
      try
      {
        var (pdfStream, fileName) = await service.GetUsersByFacilityId(facilityId);
        return File(pdfStream, "application/pdf", fileName);
      }
      catch (Exception ex)
      {
        return BadRequest(new { Message = ex.Message });
      }
    }

    [HttpGet("facility/{facilityId:int}/items/excel")]
    public async Task<IActionResult> GetItemsExcel(int facilityId)
    {
      try
      {
        var (excelStream, fileName) = await service.GetItemsByFacilityExcel(facilityId);
        return File(excelStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
      }
      catch (Exception ex)
      {
        return BadRequest(new { Message = ex.Message });
      }
    }

    [HttpGet("facility/{facilityId:int}/users/excel")]
    public async Task<IActionResult> GetUsersExcel(int facilityId)
    {
      try
      {
        var (excelStream, fileName) = await service.GetUsersByFacilityExcel(facilityId);
        return File(excelStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
      }
      catch (Exception ex)
      {
        return BadRequest(new { Message = ex.Message });
      }
    }

  }
}