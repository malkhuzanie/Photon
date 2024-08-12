namespace Photon.DTOs
{
    public class ItemMasterDto
    {
        public int ItemNbr { get; set; }
        public int CompanyId { get; set; }
        public int FacilityId { get; set; }
        public required string Barcode { get; set; }
        public required string Description { get; set; }
        public required string PhysicalDimension { get; set; }
        public required string TechnicalSpecification { get; set; }
        public int MinimumOrderSize { get; set; }
        public required string TimeToManufacture { get; set; }
        public decimal PurchaseCost { get; set; }
        public decimal ItemPricing { get; set; }
        public decimal ShippingCost { get; set; }
        public int PutawayTypeId { get; set; }
    }
}
