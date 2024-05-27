namespace Photon.Exceptions;

public class NotFoundException : HttpResponseException
{
  public NotFoundException(int statusCode, string message, object? value = null)
    : base(statusCode, message, value)
  {
  }

  public NotFoundException(string message) : base(message)
  {
  }
}

public class IllegalArgumentException : HttpResponseException
{
  public IllegalArgumentException(int statusCode, string message, object? value = null)
    : base(statusCode, message, value)
  {
  }
  
  public IllegalArgumentException(string message) : base(message)
  {
  }
}
