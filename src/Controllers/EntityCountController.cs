using Microsoft.AspNetCore.Mvc;
using Photon.DTOs.Response;
using Photon.Services;

namespace Photon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntityCountController(EntityCountService service) : ControllerBase
    {
        private readonly EntityCountService _service = service;

        [HttpGet]
        public async Task<ActionResult<EntityCountsDto>> GetEntityCounts()
        {
            var counts = await _service.GetEntityCounts();
            return Ok(counts);
        }
    }
}
