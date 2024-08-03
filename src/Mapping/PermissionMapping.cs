using Photon.Data;
using Photon.DTOs;
using Photon.DTOs.Request;
using Photon.Models;
namespace Photon.Mapping;

public static class PermissionMapping
{
  public static Task<Permission> ToPermission(this PermissionDto perm, PhotonContext context)
  {
    return Task.Run(() => new Permission { Name = perm.Name });
  }
}
