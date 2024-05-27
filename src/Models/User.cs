using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Photon.Encryption;

namespace Photon.Models;

[Index(nameof(User.Username), IsUnique = true)]
public class User
{
  public int Id { get; init; }
  [MaxLength(30)] public required string Username { get; set; }
  [MaxLength(255)] public required string FirstName { get; set; }
  [MaxLength(255)] public required string LastName { get; set; }
  [MaxLength(255)] public required string Email { get; set; }

  [JsonIgnore] public string PasswordHash { get; private set; }
  
  public required string Password
  {
    set => PasswordHash = Hasher.Hash(value).Result;
  }
  
  public required string Image { get; set; }
  public required int HourlyWage { get; set; }
  public required DateOnly HireDate { get; set; }
  
  [JsonIgnore] 
  public int FacilityId { get; set; }
  public virtual required Facility Facility { get; set; }
  
  [JsonIgnore]
  public int EquipmentId { get; set; }
  public virtual required Equipment Equipment { get; set; }
  
  public virtual required ICollection<Role> Roles { get; set; }
}
