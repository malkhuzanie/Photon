using Photon.Models;
using Photon.DTOs;
using Photon.Data;
using Photon.src.Models;

namespace Photon.Mapping
{
    public static class PutawayTypeMapping
    {
        public static async Task<PutawayType> ToPutawayType(this PutawayTypeDto dto)
        {
            return new PutawayType
            {
                PutawayTypeCode = dto.PutawayTypeCode
            };
        }
    }
}
