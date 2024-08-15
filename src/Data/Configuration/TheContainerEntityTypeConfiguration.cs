using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photon.src.Models;

namespace Photon.src.Data.Configuration
{
    public class TheContainerEntityTypeConfiguration : IEntityTypeConfiguration<Container>
    {
        public void Configure(EntityTypeBuilder<Container> builder)
        {
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Model).IsRequired();
        }
    }
}
