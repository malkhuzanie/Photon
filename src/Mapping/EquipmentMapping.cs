using Photon.Data;
using Photon.DTOs;
using Photon.Models;

namespace Photon.Mapping;

public static partial class Mapper
{
  public static Task<Equipment> ToEquipment(this EquipmentDto equip)
  {
    return Task.Run(() => new Equipment { Name = equip.Name, Description = equip.Description });
  }
}