using Microsoft.AspNetCore.Mvc;
using Photon.Services;
using Photon.Models;
using Photon.DTOs;
using Photon.DTOs.Request;

namespace Photon.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(UserService service) : ControllerBase
{
  [HttpGet]
  public async Task<IEnumerable<User>> GetAll()
  {
    return await service.GetAll();
  }
  
  [HttpGet("{id:int}")]
  public async Task<ActionResult<User>> GetById(int id)
  {
    var user = await service.GetById(id);
    return (user is not null ? user : NotFound());
  }

  [HttpPost]
  public async Task<ActionResult> Create(UserDto _user)
  {
    var user = await service.Create(_user);
    return CreatedAtAction(
      nameof(GetById),
      new { id = user.Id },
      user
    );
  }

  [HttpPut("{id:int}")]
  public async Task<IActionResult> Update(int id, UserDto _user)
  {
    await service.Update(id, _user);
    return NoContent();
  }

  [HttpDelete("{id:int}")]
  public async Task<IActionResult> Delete(int id)
  {
    if (await service.Delete(id) == false)
    {
      return BadRequest("user is not found in the database.");
    }
    return NoContent();
  }
}
