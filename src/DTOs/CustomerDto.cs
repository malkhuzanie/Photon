namespace Photon.DTOs;

public class CustomerDto
{
  public int Id { get; set; }
  public required string Name { get; set; }
  public required ContactDto Contact { get; set; }
}