using Microsoft.AspNetCore.Mvc;
using Photon.Services;
using Photon.Models;
using Photon.DTOs;

namespace Photon.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaterialController(MaterialService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Material>> GetAll()
        {
            return await service.GetAll();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Material>> GetById(int id)
        {
            var material = await service.GetById(id);
            return material is not null ? Ok(material) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Create(MaterialDto _material)
        {
            var material = await service.Create(_material);
            return CreatedAtAction(
              nameof(GetById),
              new { id = material.Id },
              material
            );
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, MaterialDto material)
        {
            await service.Update(id, material);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await service.Delete(id) == false)
            {
                return BadRequest("Supplier is not found in the database.");
            }
            return NoContent();
        }
    }
}
