using Microsoft.EntityFrameworkCore;
using Photon.Models;
using Photon.Data;
using Photon.DTOs;
using Photon.Mapping;
using Photon.Exceptions;
using Photon.src.Models;

namespace Photon.Services
{
    public class PutawayTypeService(PhotonContext context)
    {

        public async Task<IEnumerable<PutawayType>> GetAll()
        {
            return await context.PutawayTypes
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<PutawayType?> GetById(int id)
        {
            return await context.PutawayTypes
                .AsNoTracking()
                .SingleOrDefaultAsync(pt => pt.Id == id);
        }

        public async Task<PutawayType> Create(PutawayTypeDto dto)
        {
            if (await context.RecordExists<PutawayType>(pt => pt.PutawayTypeCode == dto.PutawayTypeCode))
                throw new IllegalArgumentException("A PutawayType with the same code already exists");

            var putawayType = await dto.ToPutawayType();
            context.PutawayTypes.Add(putawayType);
            await context.SaveChangesAsync();
            return putawayType;
        }

        public async Task Update(int id, PutawayTypeDto dto)
        {
            var putawayType = await context.PutawayTypes.FindAsync(id) ??
                throw new NotFoundException("PutawayType not found");

            putawayType.PutawayTypeCode = dto.PutawayTypeCode;
            await context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var putawayType = await context.PutawayTypes.FindAsync(id);
            if (putawayType == null)
            {
                return false;
            }

            context.PutawayTypes.Remove(putawayType);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
