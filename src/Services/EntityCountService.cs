using Microsoft.EntityFrameworkCore;
using Photon.Data;
using Photon.DTOs.Response;

namespace Photon.Services
{
    public class EntityCountService(PhotonContext context)
    {
        private readonly PhotonContext _context = context;

        public async Task<EntityCountsDto> GetEntityCounts()
        {
            var userCount = await _context.Users.CountAsync();
            var supplierCount = await _context.Suppliers.CountAsync();
            var facilityCount = await _context.Facilities.CountAsync();
            var companyCount = await _context.Companies.CountAsync();

            return new EntityCountsDto
            {
                UserCount = userCount,
                SupplierCount = supplierCount,
                FacilityCount = facilityCount,
                CompanyCount = companyCount
            };
        }
    }
}
