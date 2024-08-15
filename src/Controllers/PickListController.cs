using Microsoft.AspNetCore.Mvc;
using Photon.DTOs.Request;
using Photon.DTOs.Response;
using Photon.Mapping;
using Photon.Models;
using Photon.Services;

namespace Photon.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PickListController(PickListService service)
  : ControllerBase
{
  [HttpGet("{plNbr:int}")]
  public async Task<ActionResult<PickListResponseDto>> GetById(int plNbr)
  {
    var pl = await service.GetById(plNbr);
    return (pl != null ? pl.ToPickListResponseDto() : NotFound());
  }

  [HttpGet]
  public async Task<IEnumerable<PickListResponseDto>> GetAll()
  {
    return (await service.GetAll()).Select(pl => pl.ToPickListResponseDto());
  }
  
  [HttpPost]
  public async Task<IActionResult> Create(PickListDto _pl)
  {
    var pl = (await service.Create(_pl)).ToPickListResponseDto();
    return CreatedAtAction(
      nameof(GetById),
      new { plNbr = pl.PlNbr },
      pl
    );
  }
  
}