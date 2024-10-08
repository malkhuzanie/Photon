using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Photon.Services;
using Photon.DTOs;
using Photon.DTOs.Request;
using Photon.Http;

namespace Photon.Controllers;

[ApiController]
[Route("api/user/")]
[EnableCors("AllowAll")]
public class AuthController(AuthService service) : ControllerBase
{
  [HttpPost]
  [HttpOptions]
  [AllowAnonymous]
  [Route("login")]
  public async Task<IActionResult> Login(UserLoginDto login)
  {
    if (!(await service.Authenticate(login)))
    {
      return Unauthorized();
    }
    return Ok(new { token = await service.GenerateToken(login) });
  }
}
