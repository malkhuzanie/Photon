namespace Photon.Dto.Request;

public class PickListItemDto 
{
  public required int PoNbr { get; set; } 
  public required int ItemId { get; set; }
  public string? PickLocation { get; set; }
  public int? FromContainerId { get; set; }
  public int? ToContainerId { get; set; }
  public int? ItemPickupStatusId { get; set; }
}
