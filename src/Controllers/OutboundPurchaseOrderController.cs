using Microsoft.AspNetCore.Mvc;
using Photon.DTOs.Response;
using Photon.Exceptions;
using Photon.Mapping;
using Photon.Services;

namespace Photon.Controllers;

[ApiController]
[Route("api/po/in_po")]
public class OutboundPurchaseOrderController(OutboundPurchaseOrderService service)
  : ControllerBase
{
  [HttpGet("{poNbr:int}")]
  public async Task<ActionResult<OutboundPurchaseOrder>> GetById(int poNbr)
  {
    var po = await service.GetById(poNbr);
    return (po != null ? po.ToOutboundPurchaseOrderResponseDto() : NotFound());
  }
  
    
  [HttpGet]
  public async Task<IEnumerable<OutboundPurchaseOrder>> GetAll()
  {
    return (await service.GetAll()).Select(po => po.ToOutboundPurchaseOrderResponseDto());
  }
  
  [HttpPost]
  public async Task<ActionResult<OutboundPurchaseOrder>> Create(
    OutboundPurchaseOrderDto _po)
  {
    var po = await service.Create(_po);
    return CreatedAtAction(
      nameof(GetById),
      new { poNbr = po.PoNbr },
      po
    );
  }

  [HttpDelete("{poNbr:int}")]
  public async Task<ActionResult> Delete(int poNbr)
  {
    if (!(await service.Delete(poNbr)))
    {
      throw new NotFoundException("Purchase order is not found");
    }
    return NoContent();
  }
  
  [HttpPut("{poNbr:int}")]
  public async Task<ActionResult> Update(int poNbr, OutboundPurchaseOrderDto _po)
  {
    await service.Update(poNbr, _po);
    return NoContent();
  }
}