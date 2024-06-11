using Microsoft.EntityFrameworkCore;
using Photon.Data;
using Photon.DTOs;
using Photon.Exceptions;
using Photon.Interfaces;
using Photon.Models;
using Photon.Mapping;

namespace Photon.Services;

public class FacilityService(PhotonContext context)
  : IEntityService<Facility, FacilityDto>
{
  private async Task<int?> FacilityCodeExists(string code)
  {
    return (await (from f in context.Facilities
      where f.FacilityCode == code
      select f).FirstOrDefaultAsync())?.Id;
  }

  public async Task<Facility?> Find(int id)
  {
    return await (from f in context.Facilities
      where f.Id == id
      select f).FirstOrDefaultAsync();
  }

  public async Task<Facility?> GetById(int id)
  {
    return await (from f in context.Facilities
        where f.Id == id
        select new Facility { Id = f.Id, FacilityCode = f.FacilityCode }
      ).FirstOrDefaultAsync();
  }

  public async Task<IEnumerable<Facility>> GetAll()
  {
    return await (from f in context.Facilities
        select new Facility { Id = f.Id, FacilityCode = f.FacilityCode }
      ).ToListAsync();
  }

  public async Task<Facility> Create(FacilityDto _facility)
  {
    var facility = await _facility.ToFacility();
    if (await FacilityCodeExists(facility.FacilityCode) != null)
    {
      throw new IllegalArgumentException("An existing facility with the same code exists.");
    }

    context.Add(facility);
    await context.SaveChangesAsync();
    return facility;
  }

  public async Task Update(int id, FacilityDto _facility)
  {
    var facility = await Find(id);
    if (facility == null)
    {
      throw new NotFoundException("facility is not found.");
    }

    var newFacility = (await _facility.ToFacility());
    context.Facilities.Remove(facility);
    context.Add(newFacility);
    await context.SaveChangesAsync();
  }

  public async Task<bool> Delete(int id)
  {
    if (await context.Facilities.FindAsync(id) is not { } facility)
    {
      return false;
    }

    context.Facilities.Remove(facility);
    await context.SaveChangesAsync();
    return true;
  }
}