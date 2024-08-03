using Microsoft.AspNetCore.Mvc;
using Photon.DTOs.Response;
using Photon.Models;
using Photon.Services;

namespace Photon.Controllers;

[ApiController]
[Route("api/po/ib_po_status")]
public class InboundPurchaseOrderStatusController(InboundPurchaseOrderStatusService service) 
  : ControllerBase
{
  [HttpGet("{id:int}")]
  public async Task<ActionResult<PurchaseOrderStatusDto>> GetById(int id)
  {
    var status = await service.GetById(id);
    return (status != null ? status : NotFound());
  }
  
  [HttpGet]
  public async Task<IEnumerable<PurchaseOrderStatusDto>> GetAll()
  {
    return await service.GetAll();
  }
}