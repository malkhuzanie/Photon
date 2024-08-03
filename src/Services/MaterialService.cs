using Humanizer;
using Microsoft.EntityFrameworkCore;
using Photon.Data;
using Photon.DTOs;
using Photon.DTOs.Request;
using Photon.Exceptions;
using Photon.Extensions;
using Photon.Interfaces;
using Photon.Mapping;
using Photon.Models;

namespace Photon.Services
{
    public class MaterialService(PhotonContext context) : IEntityService<Material, MaterialDto>
    {
        public async Task<Material> Create(MaterialDto materialDto)
        {
            var material = materialDto.ToMaterial();
            await context.Materials.AddAsync(material);
            await context.SaveChangesAsync();
            return material;
        }

        public async Task<bool> Delete(int id)
        {
            var material = await context.Materials.FindAsync(id);
            if (material is null)
                return false;
            context.Materials.Remove(material);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Material>> GetAll()
        {
            return await context.Materials.AsNoTracking().ToListAsync();
        }

        public async Task<Material?> GetById(int id)
        {
            return await context.Materials.AsNoTracking()
                .SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task Update(int id, MaterialDto materialDto)
        {
            var material = await context.Materials.FindAsync(id) ??
               throw new NotFoundException("Material is not found in the database.");
            material.UpdateFrom(materialDto.ToMaterial());
            await context.SaveChangesAsync();
        }
    }
}