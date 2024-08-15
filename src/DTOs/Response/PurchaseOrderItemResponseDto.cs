using Photon.Models.PurchaseOrder;

namespace Photon.DTOs.Response;

public class PurchaseOrderItemResponseDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int OrderedQuantity { get; set; }
    public int ShippedQuantity { get; set; }
    public int DeliveredQuantity { get; set; }
    public ItemPickupStatus? ItemPickupStatus { get; set; }
}