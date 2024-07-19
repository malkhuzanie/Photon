namespace Photon.DTOs
{
    public class ItemDto
    {
        
        public required string Name { get; set; }

        public DateOnly ManufacturerDate { get; set; }

        public DateOnly ExpiringDate { get; set; }

        public int FacilityId { get; set; }
    }
}
