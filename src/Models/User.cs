using System.Text.Json.Serialization;
using Photon.Encryption;

namespace Photon.Models;

public class User
{
  public int Id { get; init; }
  public required string Username { get; set; }
  public required string FirstName { get; set; }
  public required string LastName { get; set; }
  public required string Email { get; set; }

  [JsonIgnore] 
  public string PasswordHash { get; private set; }
  public string Password
  {
    set => PasswordHash = Hasher.Hash(value).Result;
  }
  
  public required string Image { get; set; }
  public int HourlyWage { get; set; }
  public DateOnly HireDate { get; set; }
  
  public virtual required Facility Facility { get; set; }
  
  public virtual required Equipment Equipment { get; set; }

  public virtual required ICollection<Role> Roles { get; set; } = [];
}
