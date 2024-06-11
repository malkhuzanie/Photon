using Microsoft.AspNetCore.Mvc;
using Photon.Services;
using Photon.Models;
using Photon.DTOs;

namespace Photon.Controllers;

[ApiController]
[Route("[controller]")]
public class EquipmentController(EquipmentService service)
  : ControllerBase
{
  [HttpGet("{id:int}")]
  public async Task<ActionResult<Equipment>> GetById(int id)
  {
    var equipment = await service.GetById(id);
    return (equipment is not null ? equipment : NotFound());
  }

  [HttpGet]
  public async Task<IEnumerable<Equipment>> GetAll()
  {
    return await service.GetAll();
  }

  [HttpPost]
  public async Task<IActionResult> Create(EquipmentDto _equipment)
  {
    var equipment = await service.Create(_equipment);
    return CreatedAtAction(nameof(GetById), new { id = equipment.Id }, equipment);
  }

  [HttpPut("{id:int}")]
  public async Task<IActionResult> Update(int id, EquipmentDto _equipment)
  {
    if (id != _equipment.Id)
    {
      return BadRequest("The provided ID doesn't match the ID of the new Equipment");
    }

    await service.Update(id, _equipment);
    return NoContent();
  }

  [HttpDelete("{id:int}")]
  public async Task<IActionResult> Delete(int id)
  {
    if (await service.Delete(id) == false)
    {
      return BadRequest("No equipment with the provided ID");
    }

    return NoContent();
  }
}