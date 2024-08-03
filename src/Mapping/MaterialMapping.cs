using Photon.DTOs;
using Photon.DTOs.Request;
using Photon.Models;

namespace Photon.Mapping
{
    public static class MaterialMapping
    {
        public static Material ToMaterial(this MaterialDto materialDto)
        {
            return new Material
            {
                Name = materialDto.Name
            };
        }
    }
}