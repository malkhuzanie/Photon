using Photon.Models;

namespace Photon.Extensions;

public static class MaterialExtension
{
  public static void UpdateFrom(this Material material, Material newMaterial, Action<Material>? modify = null)
  {
    material.Name = newMaterial.Name;
    modify?.Invoke(material);
  }
}