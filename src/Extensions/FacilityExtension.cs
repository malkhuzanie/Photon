using Photon.DTOs;
using Photon.Models;

namespace Photon.Extensions;

public static class FacilityExtension
{
  // update directly from the Dto object
  public static void UpdateFrom(this Facility facility, FacilityDto newFacility,
    Action<Facility>? modify = null)
  {
    facility.FacilityCode = newFacility.FacilityCode;
    modify?.Invoke(facility);
  }
  
  public static void UpdateFrom(this Facility facility, Facility newFacility,
    Action<Facility>? modify = null)
  {
    facility.FacilityCode = newFacility.FacilityCode;
    modify?.Invoke(facility);
  }
}