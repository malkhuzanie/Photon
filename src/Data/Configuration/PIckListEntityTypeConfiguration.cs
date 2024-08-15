using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photon.Models;

namespace Photon.Data.Configuration;

public class PIckListEntityTypeConfiguration
  : IEntityTypeConfiguration<PickList>
{
  public void Configure(EntityTypeBuilder<PickList> builder)
  {
    builder.HasKey(pl => pl.PlNbr);
    
    builder.HasMany(pl => pl.Items)
      .WithOne(plItem => plItem.PickList)
      .HasForeignKey(plItem => plItem.PlNbr);
  }
}