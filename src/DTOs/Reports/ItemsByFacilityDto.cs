namespace Photon.DTOs
{
    public class ItemReportDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Count { get; set; }
        public DateOnly ManufacturerDate { get; set; }
        public DateOnly ExpiringDate { get; set; }
    }
}
