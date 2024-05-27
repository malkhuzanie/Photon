namespace Photon.Mapping;

public partial class Mapper
{
  private static async Task<ValidationResult> Validate(params ValidationArg[] args)
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