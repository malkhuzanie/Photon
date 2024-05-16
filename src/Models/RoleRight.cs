namespace Photon.Models;

public class PermissionRole 
{
  public int Id { get; init; }
  public virtual required Role Role { get; set; }
  public virtual required Permission Permission { get; set; }
}
