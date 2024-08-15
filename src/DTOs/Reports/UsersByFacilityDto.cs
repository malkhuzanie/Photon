namespace Photon.DTOs
{
    public class UserReportDto
    {
        public int Id { get; init; }
        public string Username { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int HourlyWage { get; set; }
        public DateOnly HireDate { get; set; }
        public string FacilityCode { get; set; } = string.Empty;
        public IEnumerable<string> Roles { get; set; } = new List<string>();
    }
}
