using Photon.Models.PurchaseOrder;

namespace Photon.DTOs.Request;

public class PurchaseOrderItemDto
{
  public int ItemId { get; set; }
  
  public int OrderedQuantity { get; set; }
  
  public int PackedQuantity { get; set; }
  
  public int ShippedQuantity { get; set; }
  
  public int DeliveredQuantity { get; set; }

  public int ItemPickupStatusId { get; set; }
}
