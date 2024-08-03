
namespace Photon.DTOs.Request;

public class RoleDto
{
  public required string Name { get; init; }
  public required List<int> Permissions { get; init; }
}
