using Photon.Interfaces;
using Photon.Models;

namespace Photon.DTOs;

public class EquipmentDto 
{
  public int Id { get; set; }
  public required string Name { get; set; }
  public required string Description { get; set; }
}
