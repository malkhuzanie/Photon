using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photon.Models;
using Photon.src.Models;

namespace Photon.Data.Configuration;

public class PutawayTypeEntityTypeConfiguration : IEntityTypeConfiguration<PutawayType>
{
  
  public void Configure(EntityTypeBuilder<PutawayType> builder)
  {
    builder.Property(p => p.PutawayTypeCode).IsRequired();
  }
  
}