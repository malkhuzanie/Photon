using Photon.DTOs;
using Photon.Models;

namespace Photon.Mapping;

public static partial class Mapper
{
  public static async Task<Facility> ToFacility(this FacilityDto facility)
  {
    return await Task.Run(() => new Facility { FacilityCode = facility.FacilityCode });
  }
}