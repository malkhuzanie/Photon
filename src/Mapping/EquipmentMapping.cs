using Photon.Data;
using Photon.DTOs;
using Photon.Models;

namespace Photon.Mapping;

public static class EquipmentMapping
{
  public static Task<Equipment> ToEquipment(this EquipmentDto equip)
  {
    return Task.Run(() => new Equipment { Name = equip.Name, Description = equip.Description });
  }
}