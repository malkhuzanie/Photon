using Microsoft.EntityFrameworkCore;
using Photon.Models;
using Photon.DTOs;
using Photon.Exceptions;
using Photon.src.Models;
using Photon.Data;

namespace Photon.Mapping
{
    public static class CompanyMapping
    {
        public static Company ToCompany(this CompanyDto companyDto)
        {
            return new Company
            {
                Name = companyDto.Name
            };
        }
    }
}
