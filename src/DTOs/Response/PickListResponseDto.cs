namespace Photon.DTOs.Response;

public class PickListResponseDto
{
  public int PlNbr { get; set; }
  
  public int UserId { get; set; }
  
  public string? Name { get; set; }

  public IEnumerable<PickListItemResponseDto>? Items { get; set; }
}