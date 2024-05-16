namespace Photon.Mapping;

public struct ValidationArg(string name, object? value)
{
  public string Name { get; } = name;
  public object? Value { get; } = value;
}

public struct MappingResult<T>(string msg, T? result)
{
  public string Msg { get; } = msg;
  public T? Result { get; } = result;
}

public struct ValidationResult(bool status, string msg)
{
  public bool Status { get;  } = status;
  public string Msg { get;  } = msg;
}

