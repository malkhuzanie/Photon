using Photon.Models;
using Photon.src.Models;

namespace Photon.Extensions;

public static class TheContainerExtension
{
  public static void UpdateFrom(this TheContainer theContainer, TheContainer newtheContainer, Action<TheContainer>? modify = null)
  {
    theContainer.Name = newtheContainer.Name;
    theContainer.Model = newtheContainer.Model;
    modify?.Invoke(theContainer);
  }
}