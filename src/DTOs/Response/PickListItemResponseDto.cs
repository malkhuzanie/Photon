using Photon.src.Models;

namespace Photon.DTOs.Response;

public class PickListItemResponseDto
{
  public int PoNbr { get; set; }
  public int ItemId { get; set; }
  public string ItemName { get; set; }
  public int Quantity { get; set; }
  public string? PickLocation { get; set; }
  public Container? FromContainer { get; set; }
  public Container? ToContainer { get; set; }
}