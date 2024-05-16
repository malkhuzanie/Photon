using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Photon.Models;
public class Facility 
{
  public int Id { get; init; }
  public required string FacilityCode { get; set; }

  [JsonIgnore]
  public virtual ICollection<User> Users
  {
    get; set; 
  } = new List<User>();
}
