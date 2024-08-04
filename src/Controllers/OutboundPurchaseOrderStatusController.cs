using Microsoft.AspNetCore.Mvc;
using Photon.DTOs.Response;
using Photon.Models;
using Photon.Services;

namespace Photon.Controllers;

[ApiController]
[Route("api/po/in_po_status")]
public class OutboundPurchaseOrderStatusController(OutboundPurchaseOrderStatusService service) 
  : ControllerBase
{
  [HttpGet("{id:int}")]
  public async Task<ActionResult<PurchaseOrderStatusResponseDto>> GetById(int id)
  {
    var status = await service.GetById(id);
    return (status != null ? status : NotFound());
  }
  
  [HttpGet]
  public async Task<IEnumerable<PurchaseOrderStatusResponseDto>> GetAll()
  {
    return await service.GetAll();
  }
}
