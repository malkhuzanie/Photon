using Photon.Dto.Request;
using Photon.Models;

namespace Photon.DTOs.Request;

public class PickListDto
{
  public required int UserId { get; set; }

  public required ICollection<PickListItemDto> Items { get; set; }
}
