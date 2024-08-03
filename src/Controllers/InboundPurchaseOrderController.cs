using Microsoft.AspNetCore.Mvc;
using Photon.DTOs;
using Photon.DTOs.Request;
using Photon.Exceptions;
using Photon.Models;
using Photon.Models.PurchaseOrder.Inbound;
using Photon.Services;

namespace Photon.Controllers;

[ApiController]
[Route("api/po/ib_po")]
public class InboundPurchaseOrderController(InboundPurchaseOrderService service)
  : ControllerBase
{
  [HttpGet("{poNbr:int}")]
  public async Task<ActionResult<InboundPurchaseOrder>> GetById(int poNbr)
  {
    var po = await service.GetById(poNbr);
    return (po != null ? po : NotFound());
  }

  [HttpGet]
  public async Task<IEnumerable<InboundPurchaseOrder>> GetAll()
  {
    return await service.GetAll();
  }
  
  [HttpPost]
  public async Task<ActionResult<InboundPurchaseOrder>> Create(InboundPurchaseOrderDto _ibpo)
  {
    var ibpo = await service.Create(_ibpo);
    return CreatedAtAction(
      nameof(GetById),
      new { poNbr = ibpo.PoNbr },
      ibpo
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
}