using System;
using Microsoft.AspNetCore.Mvc;
using Photon.DTOs.Request;
using Photon.src.Models;
using Photon.src.Services;

namespace Photon.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContainerController(ContainerService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Container>> GetAll()
        {
            return await service.GetAll();
        }
        [HttpGet("id:int")]
        public async Task<IActionResult> GetById(int id)
        {
            var theContainer = await service.GetById(id);
            return theContainer is null ? NotFound() : Ok(theContainer);
        }
        [HttpPost]
        public async Task<IActionResult> Create(TheContainerDto theContainerDto)
        {
            var theContainer = await service.Create(theContainerDto);
            return CreatedAtAction(
                nameof(GetById),
                new { id = theContainer.Id },
                theContainer);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Upadte(int id, TheContainerDto theContainerDto)
        {
            await service.Update(id, theContainerDto);
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await service.Delete(id))
                return NoContent();
            return BadRequest("The Container doesn't exist");
        }
    }
}
