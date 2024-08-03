using Microsoft.AspNetCore.Mvc;
using Photon.Models;
using Photon.Services;
using StatusResponseDto = Photon.DTOs.Response.InboundPurchaseOrderStatusDto;

namespace Photon.Controllers;

[ApiController]
[Route("api/po/ib_po_status")]
public class InboundPurchaseOrderStatusController(InboundPurchaseOrderStatusService service) 
  : ControllerBase
{
  [HttpGet("{id:int}")]
  public async Task<ActionResult<StatusResponseDto>> GetById(int id)
  {
    var status = await service.GetById(id);
    return (status != null ? status : NotFound());
  }
  
  [HttpGet]
  public async Task<IEnumerable<StatusResponseDto>> GetAll()
  {
    return await service.GetAll();
  }
}