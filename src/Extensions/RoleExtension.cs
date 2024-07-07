using Photon.Models;

namespace Photon.Extensions;

public static class RoleExtension
{
  public static void UpdateFrom(this Role role, Role newRole, Action<Role>? modify = null)
  {
    role.Name = newRole.Name;
    role.Permissions = newRole.Permissions;
    modify?.Invoke(role);
  }
}