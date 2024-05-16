using Microsoft.AspNetCore.Mvc;
using Photon.Services;
using Photon.Models;
using Photon.DTOs;
using Photon.Http;

namespace Photon.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(UserService service) : ControllerBase
{
  [HttpGet]
  public async Task<IEnumerable<User>> GetAll()
  {
    return await service.GetAll();
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<User>> GetById(int id)
  {
    var user = await service.GetById(id);
    return (user is not null ? user : NotFound());
  }
  
  [HttpPost]
  public async Task<IActionResult> Create(UserDto _user)
  {
    var user = await service.Create(_user);
    if (user.Result != null)
    {
      return CreatedAtAction(
        nameof(GetById), 
        new { id = user.Result.Id }, 
        user.Result
      );
    }
    return BadRequest(new JsonResponse(400, user.Msg));
  }
}
