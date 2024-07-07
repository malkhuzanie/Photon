using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photon.Models;

namespace Photon.Data.Configuration;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
  List<string> required =
  [
    nameof(User.Username), nameof(User.FirstName),
    nameof(User.LastName), nameof(User.Email),
    nameof(User.Image), nameof(User.HourlyWage),
    nameof(User.HireDate)
  ];
  
  public void Configure(EntityTypeBuilder<User> builder)
  {
    builder.HasIndex(u => u.Username).IsUnique();
    builder.Property(u => u.Username).HasMaxLength(30);

    builder.Property(u => u.FirstName).HasMaxLength(255);
    builder.Property(u => u.LastName).HasMaxLength(255);
    
    builder.HasIndex(u => u.Email).IsUnique();
    builder.Property(u => u.Email).HasMaxLength(255);
    
    builder.Properties(p => required.Contains(p.Name))
      .ForEach(p => p.IsRequired());
  }
  
}