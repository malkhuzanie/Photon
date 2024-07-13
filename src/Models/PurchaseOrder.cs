namespace Photon.Models;

public class PurchaseOrder
{
  public int PoNbr { get; set; }
  public DateTime OrderDate { get; set; }
  public DateTime ShipDate { get; set; }
  public DateTime DeliveryDate { get; set; }
  public DateTime CancelDate { get; set; }
  public required string Address;
  public virtual required Facility Facility { get; set; }
  public virtual required Customer Customer { get; set; }
}