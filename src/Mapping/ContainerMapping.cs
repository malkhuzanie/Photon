using System;
using System.ComponentModel;
using Photon.DTOs.Request;
using Photon.src.Models;
using Container = Photon.src.Models.Container;

namespace Photon.src.Mapping
{
    public static class ContainerMapping
    {
        public static async Task<Container> ToContainer(this TheContainerDto theContainerDto)
        {
            return await Task.Run(() => new Container { Name = theContainerDto.Name, Model = theContainerDto.Model });
        }
    }
}
