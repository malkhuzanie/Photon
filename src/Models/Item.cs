namespace Photon.Models
{
    public class Item
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public DateTime ManufacturerDate { get; set; }
       
        public DateTime ExpiringDate { get; set; }

        public int FacilityId { get; set; }
    
        public virtual required Facility Facility { get; set; }
    }
}