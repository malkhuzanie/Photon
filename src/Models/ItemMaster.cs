using System.Text.Json.Serialization;
using Photon.Models;

namespace Photon.src.Models
{
    public class ItemMaster
    {
        public int Id { get; set; }
        public required string Barcode { get; set; }
        public required string Description { get; set; }
        public required string PhysicalDimension { get; set; }
        public required string TechnicalSpecification { get; set; }
        public int MinimumOrderSize { get; set; }
        public required string TimeToManufacture { get; set; }
        public decimal PurchaseCost { get; set; }
        public decimal ItemPricing { get; set; }
        public decimal ShippingCost { get; set; }

        public virtual Company? Company { get; set; }
        public virtual PutawayType? PutawayType { get; set; }
    }
}
