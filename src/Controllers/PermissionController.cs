using Microsoft.AspNetCore.Mvc;
using Photon.Services;
using Photon.Models;
using Photon.DTOs;

namespace Photon.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PermissionController(PermissionService service) : ControllerBase
{
  [HttpGet]
  public async Task<IEnumerable<Permission>> GetAll()
  {
    return await service.GetAll();
  }

  [HttpGet("{id:int}")]
  public async Task<ActionResult<Permission>> GetById(int id)
  {
    var permission = await service.GetById(id);
    return (permission is not null ? permission : NotFound());
  }

  [HttpPost]
  public async Task<ActionResult> Create(PermissionDto perm)
  {
    var permission = await service.Create(perm);
    return CreatedAtAction(
      nameof(GetById),
      new { id = permission.Id },
      permission
    );
  }

  [HttpDelete("{id:int}")]
  public async Task<ActionResult> Delete(int id)
  {
    if (await service.Delete(id) == false)
    {
      return BadRequest("Permission is not found.");
    }
    return NoContent();
  }
}
