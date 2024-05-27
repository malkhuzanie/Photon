using Microsoft.AspNetCore.Mvc;
namespace Photon.Controllers;

[ApiController]
public class ExceptionController : ControllerBase
{
  [Route("/error")]
  protected  IActionResult HandleError()
  {
    return Problem();
  }
}