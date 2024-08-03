namespace Photon.DTOs.Request
{
    public class ItemDto
    {

        public required string Name { get; set; }

        public int Count { get; set; } = 0;

        public DateOnly ManufacturerDate { get; set; }

        public DateOnly ExpiringDate { get; set; }

        public int FacilityId { get; set; }
    }
}
