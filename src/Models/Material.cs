using System.Runtime.ConstrainedExecution;
using System.Text.Json.Serialization;

namespace Photon.Models
{
    public class Material
    {
        public int Id { get; set; }

        public required string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<Item> Items { get; set; } = [];
    }
}