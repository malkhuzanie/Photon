using System.ComponentModel.DataAnnotations;

namespace Photon.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public virtual Contact? Contact { get; set; }
    }
}