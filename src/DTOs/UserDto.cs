using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Photon.Encryption;

namespace Photon.DTOs;

public class UserDto
{
  public int? Id { get; set; }
  // [RegularExpression("^(?=.{8, 20})(?![._])(?!.*[._]{2})[a-zA-Z._] + (?<![._])")]
  public required string Username { get; set; }
  
  [MaxLength(255)]
  public required string FirstName { get; set; }
  
  [MaxLength(255)]
  public required string LastName { get; set; }
  
  [EmailAddress]
  public required string Email { get; set; }

  public required string Password { get; set; }
  
  public required string Image { get; set; }
  public required int HourlyWage { get; set; }
  public required DateOnly HireDate { get; set; }
  
  public required int FacilityId { get; set; }
  public required int EquipmentId { get; set; }
  public required List<int> Roles { get; set; }
}

