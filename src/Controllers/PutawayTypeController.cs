using Microsoft.AspNetCore.Mvc;
using Photon.Services;
using Photon.Models;
using Photon.DTOs;
using Photon.src.Models;

namespace Photon.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PutawayTypeController(PutawayTypeService service) : ControllerBase
    {

        [HttpGet]
        public async Task<IEnumerable<PutawayType>> GetAll()
        {
            return await service.GetAll();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PutawayType>> GetById(int id)
        {
            var putawayType = await service.GetById(id);
            return putawayType is not null ? Ok(putawayType) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Create(PutawayTypeDto dto)
        {
            var putawayType = await service.Create(dto);
            return CreatedAtAction(
                nameof(GetById),
                new { id = putawayType.Id },
                putawayType
            );
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, PutawayTypeDto dto)
        {
            await service.Update(id, dto);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await service.Delete(id) == false)
            {
                return BadRequest("PutawayType not found in the database.");
            }
            return NoContent();
        }
    }
}
