namespace Photon.DTOs.Request;

public class CustomerDto
{
  public required string Name { get; set; }
  public required ContactDto Contact { get; set; }
}
