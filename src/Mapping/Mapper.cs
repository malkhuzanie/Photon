using Microsoft.EntityFrameworkCore;
using Photon.Models;
using Photon.DTOs;
using Photon.Data;
using Photon.Exceptions;

namespace Photon.Mapping;

public static class Mapper
{
  public static async Task<ValidationResult> Validate(params ValidationArg[] args)
  {
    return await Task.Run(() =>
    {
      foreach (var arg in args)
      {
        if (arg.Value == null)
        {
          return new ValidationResult(false, arg.Name);
        }
      }
      return new ValidationResult(true, string.Empty);
    });
  }
}
