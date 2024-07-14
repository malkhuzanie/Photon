namespace Photon.DTOs
{
    public class ItemDto
    {
        public int? Id { get; set; }

        public required string Name { get; set; }

        public DateTime ManufacturerDate { get; set; }

        public DateTime ExpiringDate { get; set; }

        public int FacilityId { get; set; }
    }
}
