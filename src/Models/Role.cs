using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace Photon.Models;

public class Role
{
  public int Id { get; init; }
  public required string Name { get; set; }

  public virtual ICollection<Permission> Permissions
  {
    get; set; 
  } = new List<Permission>();

  [JsonIgnore] 
  public virtual ICollection<User> Users { get; } = new List<User>();
}