using System.Text.Json.Serialization;
using Photon.Encryption;

namespace Photon.Models;

public class User
{
  public int Id { get; init; }
  public string Username { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string Email { get; set; }

  [JsonIgnore] 
  public string PasswordHash { get; private set; }
  public string Password
  {
    set => PasswordHash = Hasher.Hash(value).Result;
  }
  
  public string Image { get; set; }
  public int HourlyWage { get; set; }
  public DateOnly HireDate { get; set; }
  
  [JsonIgnore] 
  public int FacilityId { get; set; }
  public virtual Facility Facility { get; set; }
  
  [JsonIgnore]
  public int EquipmentId { get; set; }
  public virtual Equipment Equipment { get; set; }

  public virtual ICollection<Role> Roles { get; set; } = [];
}
