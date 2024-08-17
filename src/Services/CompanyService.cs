using Microsoft.EntityFrameworkCore;
using Photon.Models;
using Photon.Data;
using Photon.DTOs;
using Photon.Mapping;
using Photon.Exceptions;
using Photon.Extensions;
using Photon.Interfaces;
using Photon.src.Models;

namespace Photon.Services
{
    public class CompanyService(PhotonContext context) : IEntityService<Company, CompanyDto>
    {

        public async Task<IEnumerable<Company>> GetAll()
        {
            return await context.Companies
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Company?> GetById(int id)
        {
            return await context.Companies
                .AsNoTracking()
                .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Company> Create(CompanyDto companyDto)
        {
            if (await context.RecordExists<Company>(c => c.Name == companyDto.Name))
                throw new IllegalArgumentException("A company with the same name already exists");

            var company = companyDto.ToCompany();
            context.Companies.Add(company);
            await context.SaveChangesAsync();
            return company;
        }

        public async Task Update(int id, CompanyDto companyDto)
        {
            var company = await context.Companies.FindAsync(id) ??
                throw new NotFoundException("Company not found");

            company.Name = companyDto.Name;
            await context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var company = await context.Companies.FindAsync(id);
            if (company == null)
            {
                return false;
            }

            context.Companies.Remove(company);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
