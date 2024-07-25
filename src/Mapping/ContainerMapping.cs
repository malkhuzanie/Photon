using System;
using System.ComponentModel;
using Photon.src.DTOs;
using Photon.src.Models;
namespace Photon.src.Mapping
{
    public static class ContainerMapping
    {
        public static async Task<TheContainer> ToContainer(this TheContainerDto theContainerDto)
        {
            return await Task.Run(() => new TheContainer { Name = theContainerDto.Name, Model = theContainerDto.Model });
        }
    }
}
