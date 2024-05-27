using Photon.Data;
using Photon.DTOs;
using Photon.Models;
namespace Photon.Mapping;

public static partial class Mapper 
{
  public static Task<Permission> FromDto(this PermissionDto perm, PhotonContext context)
  {
    return Task.Run(() => new Permission { Name = perm.Name });
  }
}
