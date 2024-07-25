using System;
using Microsoft.EntityFrameworkCore;
using Photon.Data;
using Photon.Exceptions;
using Photon.Extensions;
using Photon.Interfaces;
using Photon.Services;
using Photon.src.DTOs;
using Photon.src.Mapping;
using Photon.src.Models;

namespace Photon.src.Services
{
    public class TheContainerService(PhotonContext context) : IEntityService<TheContainer, TheContainerDto>
    {
        public async Task<TheContainer> Create(TheContainerDto theContainerDto)
        {
            if (await context.RecordExists<TheContainer>(c => c.Name == theContainerDto.Name))
                throw new IllegalArgumentException("The Container with the same name is exists!");

            var theContainer = await theContainerDto.ToContainer();
            context.TheContainers.Add(theContainer);
            await context.SaveChangesAsync();
            return theContainer;
        }

        public async Task<bool> Delete(int id)
        {
            var theContainer = await context.TheContainers.FindAsync(id);
            if (theContainer is null)
                return false;
            context.TheContainers.Remove(theContainer);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TheContainer>> GetAll()
        {
            return await context.TheContainers.AsNoTracking().ToListAsync();
        }

        public async Task<TheContainer?> GetById(int id)
        {
            return await context.TheContainers.AsNoTracking().SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task Update(int id, TheContainerDto theContainerDto)
        {
            var theContainer = await context.TheContainers.FindAsync(id) ??
                throw new IllegalArgumentException($"NO such Container with this {id} Id");
            theContainer.UpdateFrom(await theContainerDto.ToContainer());
            await context.SaveChangesAsync();
        }
    }
}
