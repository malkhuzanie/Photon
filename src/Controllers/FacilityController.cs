using Microsoft.AspNetCore.Mvc;
using Photon.DTOs;
using Photon.Models;
using Photon.Services;

namespace Photon.Controllers;

public class FacilityController(FacilityService service) : ControllerBase
{
  [HttpGet("{id:int}")]
  public async Task<ActionResult<Facility>> GetById(int id)
  {
    var facility = await service.GetById(id);
    return (facility != null ? facility : NotFound());
  }

  [HttpGet]
  public async Task<IEnumerable<Facility>> GetAll()
  {
    return await service.GetAll();
  }

  [HttpPost]
  public async Task<IActionResult> Create(FacilityDto _facility)
  {
    var facility = await service.Create(_facility);
    return CreatedAtAction(
      nameof(GetById),
      new { id = facility.Id },
      facility
    );
  }
}