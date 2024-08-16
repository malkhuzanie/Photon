using Photon.Models;

namespace Photon.Extensions;

public static class PickListExtension
{
  public static void UpdateFrom(
    this PickList to, 
    PickList from, 
    Action<PickList>? modify = null)
  {
    to.User = from.User;
    to.Items = from.Items;
    modify?.Invoke(to);
  }
}