namespace Photon.Exceptions;

public class ValidationException(string message, List<string> validationErrors) 
  : Exception(message)
{
  public List<string> ValidationErrors { get; } = validationErrors;
}