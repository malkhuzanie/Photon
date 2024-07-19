using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photon.Models;

namespace Photon.Data.Configuration;

public class MaterialEntityTypeConfiguration : IEntityTypeConfiguration<Material>
{
  
  public void Configure(EntityTypeBuilder<Material> builder)
  {
    builder.Property(m => m.Name).IsRequired();
    builder.Property(m => m.Name).HasMaxLength(255);
  }
  
}