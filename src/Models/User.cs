using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Photon.Encryption;

namespace Photon.Models;

[Index(nameof(User.Username), IsUnique = true)]
public class User
{
  public int Id { get; init; }
  public required string Username { get; set; }
  public required string FirstName { get; set; }
  public required string LastName { get; set; }
  public required string Email { get; set; }

  private string password = string.Empty;
  public required string Password
  {
    get => password;
    init => password = Hasher.Hash(value).Result;
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
