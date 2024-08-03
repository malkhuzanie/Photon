using Microsoft.EntityFrameworkCore;
using Photon.Data;
using Photon.Models;
using Photon.DTOs;
using Photon.DTOs.Request;
using Photon.Exceptions;
using Photon.Mapping;
using Photon.Interfaces;

namespace Photon.Services;

public class EquipmentService(PhotonContext context) 
  : IEntityService<Equipment, EquipmentDto>
{
  private async Task<int?> EquipmentNameExists(string name)
  {
    return (await (from e in context.Equipments
          where e.Name == name
          select e).FirstOrDefaultAsync()
      )?.Id;
  }

  public async Task<Equipment?> Find(int id)
  {
    return await context.Equipments.FindAsync(id);
  }

  public async Task<Equipment?> GetById(int id)
  {
    return await (from e in context.Equipments
        where e.Id == id
        select e)
      .FirstOrDefaultAsync();
  }

  public async Task<IEnumerable<Equipment>> GetAll()
  {
    return await (from e in context.Equipments select e).ToListAsync();
  }

  public async Task<Equipment> Create(EquipmentDto _equipment)
  {
    var equipment = await _equipment.ToEquipment();
    if (await EquipmentNameExists(equipment.Name) != null)
    {
      throw new IllegalArgumentException(
        "An Equipment with the same name exists"
      );
    }

    context.Add(equipment);
    await context.SaveChangesAsync();
    return equipment;
  }

  public async Task Update(int id, EquipmentDto _equipment)
  {
    var oldEquipment = await Find(id);
    if (oldEquipment is null)
    {
      throw new NotFoundException("equipment is not found in the database");
    }
    var equipment = await _equipment.ToEquipment();
    context.Equipments.Remove(oldEquipment);
    context.Equipments.Add(equipment);
    await context.SaveChangesAsync();
  }

  public async Task<bool> Delete(int id)
  {
    if (await context.Equipments.FindAsync(id) is not { } equipment)
    {
      return false;
    }

    context.Equipments.Remove(equipment);
    await context.SaveChangesAsync();
    return true;
  }
}
