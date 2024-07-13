using Microsoft.EntityFrameworkCore;
using Photon.Models;
using Photon.DTOs;
using Photon.Data;
using Photon.Exceptions;
using System.Text.RegularExpressions;

namespace Photon.Mapping;

public static class Mapper
{

  private static readonly string phoneNumberPatter = @"^\+?(\d{1,3})?[-.\s]?(\()?(\d{1,4})(?(2)\))[-.\s]?(\d{1,4})[-.\s]?(\d{1,4})$";

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

  public static async Task<ValidationResult> PhoneNumberValidator(string number)
  {
    return await Task.Run(() =>
    {
      return Regex.IsMatch(number, phoneNumberPatter) ? new ValidationResult(true, string.Empty) : new ValidationResult(true, "Phone Number is not valid\n");
    });
  }

}
