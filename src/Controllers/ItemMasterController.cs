using Microsoft.AspNetCore.Mvc;
using Photon.Services;
using Photon.Models;
using Photon.DTOs;
using Photon.DTOs.Request;
using Photon.srs.Services;
using Photon.src.Models;

namespace Photon.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemMasterController(ItemMasterService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<ItemMaster>> GetAll()
        {
            return await service.GetAll();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ItemMaster>> GetById(int id)
        {
            var itemMaster = await service.GetById(id);
            return itemMaster is not null ? Ok(itemMaster) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Create(ItemMasterDto itemMasterDto)
        {
            var itemMaster = await service.Create(itemMasterDto);
            return CreatedAtAction(
                nameof(GetById),
                new { id = itemMaster.Id },
                itemMaster
            );
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, ItemMasterDto itemMasterDto)
        {
            await service.Update(id, itemMasterDto);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await service.Delete(id) == false)
            {
                return BadRequest("ItemMaster is not found in the database.");
            }
            return NoContent();
        }
    }
}
