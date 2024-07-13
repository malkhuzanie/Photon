namespace Photon.Models;

public class Customer
{
  public int Id { get; set; }
  public required string Name { get; set; }
  public virtual required Contact Contact { get; set; }
}