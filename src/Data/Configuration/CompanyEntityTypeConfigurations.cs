using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photon.Models;
using Photon.src.Models;

namespace Photon.Data.Configuration;

public class CompanyEntityTypeConfiguration : IEntityTypeConfiguration<Company>
{
  
  public void Configure(EntityTypeBuilder<Company> builder)
  {
    builder.Property(c => c.Name).IsRequired();
  }
  
}