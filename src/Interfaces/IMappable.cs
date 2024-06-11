namespace Photon.Interfaces;

public interface IMappable<in T, out TResult>
{
  public TResult To(T arg);
}