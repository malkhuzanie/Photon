using Photon.Models;
using Photon.src.Models;

namespace Photon.Extensions;

public static class TheContainerExtension
{
  public static void UpdateFrom(this Container container, Container newtheContainer, Action<Container>? modify = null)
  {
    container.Name = newtheContainer.Name;
    container.Model = newtheContainer.Model;
    modify?.Invoke(container);
  }
}