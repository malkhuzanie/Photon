using Microsoft.AspNetCore.Mvc;
using Photon.Services;
using Photon.Models;
using Photon.DTOs;
using Photon.DTOs.Request;

namespace Photon.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController(SupplierService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Supplier>> GetAll()
        {
            return await service.GetAll();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Supplier>> GetById(int id)
        {
            var supplier = await service.GetById(id);
            return supplier is not null ? Ok(supplier) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Create(SupplierDto _supplier)
        {
            var supplier = await service.Create(_supplier);
            return CreatedAtAction(
              nameof(GetById),
              new { id = supplier.Id },
              supplier
            );
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, SupplierDto supplier)
        {
            await service.Update(id, supplier);
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
