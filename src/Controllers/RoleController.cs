using Microsoft.AspNetCore.Mvc;
using Photon.Services;
using Photon.Models;

namespace Photon.Controllers;

[ApiController]
[Route("[controller]")]
public class RoleController(RoleService service) : ControllerBase 
{
  [HttpGet]
  public async Task<IEnumerable<Role>> GetAll()
  {
    return await service.GetAll();
  }
}
