using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Photon.Services;
using Photon.Models;
using Photon.DTOs;
using Photon.DTOs.Request;

namespace Photon.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "ADMINISTRATOR, SUPERVISOR")]
public class RoleController(RoleService service) : ControllerBase
{
  [HttpGet]
  public async Task<IEnumerable<Role>> GetAll()
  {
    return await service.GetAll();
  }

  [HttpGet("{id:int}")]
  public async Task<ActionResult<Role>> GetById(int id)
  {
    var role = await service.GetById(id);
    return (role is not null ? role : NotFound());
  }

  [HttpPost]
  public async Task<ActionResult> Create(RoleDto _role)
  {
    var role = await service.Create(_role);
    return CreatedAtAction(
      nameof(GetById),
      new { id = role.Id },
      role
    );
  }
  
  [HttpPut("{id:int}")]
  public async Task<IActionResult> Update(int id, RoleDto role) 
  {
    await service.Update(id, role);
    return NoContent();
  }

  [HttpDelete("{id:int}")]
  public async Task<IActionResult> Delete(int id)
  {
    if (await service.Delete(id) == false)
    {
      return BadRequest("role is not found in the database.");
    }

    return NoContent();
  }
}
