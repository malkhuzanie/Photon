using Microsoft.AspNetCore.Mvc;
using Photon.DTOs;
using Photon.Models;
using Photon.Services;

namespace Photon.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController(CustomerService service) 
  : ControllerBase
{
  [HttpGet("{id:int}")]
  public async Task<ActionResult<Customer>> GetById(int id)
  {
    var customer = await service.GetById(id);
    return (customer != null ? customer : NotFound());
  }

  [HttpGet]
  public async Task<IEnumerable<Customer>> GetAll()
  {
    return await service.GetAll();
  }

  [HttpPost]
  public async Task<IActionResult> Create(CustomerDto _customer)
  {
    var customer = await service.Create(_customer);
    return CreatedAtAction(
      nameof(GetById),
      new { id = customer.Id },
      customer
    );
  }

  [HttpPut]
  public async Task<IActionResult> Update(int id, CustomerDto _customer)
  {
    if (id != _customer.Id)
    {
      return BadRequest("customer's id doesn't match.");
    }
    await service.Update(id, _customer);
    return NoContent();
  }

  [HttpDelete("{id:int}")]
  public async Task<IActionResult> Delete(int id)
  {
    if (await service.Delete(id) == false)
    {
      return NotFound("customer is not found.");
    }
    return NoContent();
  }
}