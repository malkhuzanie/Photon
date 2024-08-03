using Photon.DTOs;
using Photon.DTOs.Request;
using Photon.Models;

namespace Photon.Mapping;

public static class FacilityMapping
{
  public static async Task<Facility> ToFacility(this FacilityDto facility)
  {
    return await Task.Run(() => new Facility { FacilityCode = facility.FacilityCode });
  }
}