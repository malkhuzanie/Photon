using System.Text.Json.Serialization;
using Photon.src.Models;
using PO = Photon.Models.PurchaseOrder;

namespace Photon.Models
{
    public class Item
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public int Count { get; set; } = 0;

        public DateOnly ManufacturerDate { get; set; }
       
        public DateOnly ExpiringDate { get; set; }  

        public int FacilityId { get; set; }
    
        public virtual required Facility Facility { get; set; }

        public virtual ItemMaster? ItemMaster { get; set; }
        
        public virtual ICollection<Material> Materials { get; set; } = [];

        [JsonIgnore]
        public virtual ICollection<PO.PurchaseOrder> PurchaseOrders { get; set; } = [];

        // public virtual ICollection<PO.PurchaseOrderItem> PurchaseOrderItems { get; set; } = [];
    }
}
