namespace Photon.Exceptions;

public class HttpResponseException : Exception
{
  public HttpResponseException(int statusCode, string message, object? value = null) 
    : base(message)
  {
    (StatusCode, Value) = (statusCode, value);
  }

  public HttpResponseException(string message)
    : base(message)
  {
  }
  
  public int StatusCode { get; }
  public object? Value { get; }
}