using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photon.Models;

namespace Photon.Data.Configuration;

public class SupplierEntityTypeConfiguration : IEntityTypeConfiguration<Supplier>
{
  
  public void Configure(EntityTypeBuilder<Supplier> builder)
  {
    builder.Property(s => s.Name).IsRequired();
    builder.Property(s => s.Name).HasMaxLength(255);
  }
  
}