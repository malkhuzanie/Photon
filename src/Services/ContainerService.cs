using System;
using Microsoft.EntityFrameworkCore;
using Photon.Data;
using Photon.DTOs.Request;
using Photon.Exceptions;
using Photon.Extensions;
using Photon.Interfaces;
using Photon.Services;
using Photon.src.Mapping;
using Photon.src.Models;

namespace Photon.src.Services
{
    public class ContainerService(PhotonContext context) : IEntityService<Container, TheContainerDto>
    {
        public async Task<Container> Create(TheContainerDto theContainerDto)
        {
            if (await context.RecordExists<Container>(c => c.Name == theContainerDto.Name))
                throw new IllegalArgumentException("The Container with the same name is exists!");

            var theContainer = await theContainerDto.ToContainer();
            context.Containers.Add(theContainer);
            await context.SaveChangesAsync();
            return theContainer;
        }

        public async Task<bool> Delete(int id)
        {
            var theContainer = await context.Containers.FindAsync(id);
            if (theContainer is null)
                return false;
            context.Containers.Remove(theContainer);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Container>> GetAll()
        {
            return await context.Containers.AsNoTracking().ToListAsync();
        }

        public async Task<Container?> GetById(int id)
        {
            return await context.Containers.AsNoTracking().SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task Update(int id, TheContainerDto theContainerDto)
        {
            var theContainer = await context.Containers.FindAsync(id) ??
                throw new IllegalArgumentException($"NO such Container with this {id} Id");
            theContainer.UpdateFrom(await theContainerDto.ToContainer());
            await context.SaveChangesAsync();
        }
    }
}
