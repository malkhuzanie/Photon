namespace Photon.DTOs
{
    public class ItemDto
    {
        public int? Id { get; set; }

        public required string Name { get; set; }

        public DateOnly ManufacturerDate { get; set; }

        public DateOnly ExpiringDate { get; set; }

        public int FacilityId { get; set; }
    }
}
