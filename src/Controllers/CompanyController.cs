using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Photon.Services;
using Photon.Models;
using Photon.DTOs;
using Photon.src.Models;

namespace Photon.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "ADMINISTRATOR, SUPERVISOR")]
    public class CompanyController(CompanyService service) : ControllerBase
    {

        [HttpGet]
        public async Task<IEnumerable<Company>> GetAll()
        {
            return await service.GetAll();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Company>> GetById(int id)
        {
            var company = await service.GetById(id);
            return company is not null ? Ok(company) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CompanyDto companyDto)
        {
            var company = await service.Create(companyDto);
            return CreatedAtAction(
                nameof(GetById),
                new { id = company.Id },
                company
            );
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, CompanyDto companyDto)
        {
            await service.Update(id, companyDto);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await service.Delete(id) == false)
            {
                return BadRequest("Company not found in the database.");
            }
            return NoContent();
        }
    }
}
