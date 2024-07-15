using Microsoft.AspNetCore.Mvc;
using Photon.DTOs;
using Photon.Models;
using Photon.Services;

namespace Photon.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController(ItemService service) : ControllerBase
    {
        [HttpGet("all")]
        public async Task<IEnumerable<Item>> GetAll()
        {
            return await service.GetAll();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Item>> GetById(int id)
        {
            var item = await service.GetById(id);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ItemDto itemDto)
        {
            var item = await service.Create(itemDto);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, ItemDto itemDto)
        {
            if (id != itemDto.Id)
            {
                return BadRequest("Item's id doesn't match");
            }
            await service.Update(id, itemDto);
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
        [HttpGet("items")]
        public async Task<IActionResult> GetAll([FromQuery] DateOnly? minExpirationDate, [FromQuery] DateOnly? maxExpirationDate, [FromQuery] string sortField = "Name", [FromQuery] bool ascendingSort = true)
        {
            var items = await service.GetAll(minExpirationDate, maxExpirationDate, sortField, ascendingSort);
            return Ok(items);
        }
    }
}