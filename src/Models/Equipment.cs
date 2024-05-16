using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Photon.Models;

public class Equipment
{
  public int Id { get; init; }
  public required string Name { get; set; }
  public required string Description { get; set; } = string.Empty;

  [JsonIgnore]
  public virtual ICollection<User> Users
  {
    get; 
  } = new List<User>();
}