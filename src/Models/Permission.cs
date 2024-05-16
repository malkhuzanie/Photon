using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Photon.Models;

public class Permission 
{
  public int Id { get; init; }
  public required string Name { get; set; }
  
  [JsonIgnore]
  public virtual ICollection<Role> Roles { get; } = new List<Role>();
}
