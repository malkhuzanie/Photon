using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photon.Models;

namespace Photon.Data.Configuration;

public class ItemEntityTypeConfiguration : IEntityTypeConfiguration<Item>
{
  
  public void Configure(EntityTypeBuilder<Item> builder)
  {
    builder.Property(i => i.Name).IsRequired();
    builder.Property(i => i.Name).HasMaxLength(255);
  }
  
}