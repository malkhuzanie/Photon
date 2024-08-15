namespace Photon.Extensions;

public static class TaskExtension
{
  public static Task WhenAll(params ValueTask<Object>[] tasks)
  {
    return Task.WhenAll(tasks.Select(t => t.AsTask()));
  }
}