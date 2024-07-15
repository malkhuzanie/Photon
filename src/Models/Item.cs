namespace Photon.Models
{
    public class Item
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public DateOnly ManufacturerDate { get; set; }
       
        public DateOnly ExpiringDate { get; set; }

        public int FacilityId { get; set; }
    
        public virtual required Facility Facility { get; set; }
    }
}
