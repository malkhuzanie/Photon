using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photon.Models;

namespace Photon.Data.Configuration;

public class PickListItemEntityTypeConfiguration
  : IEntityTypeConfiguration<PickListItem>
{
  public void Configure(EntityTypeBuilder<PickListItem> builder)
  {
    builder.HasKey(pli => new { pli.PlNbr, pli.PoNbr, pli.ItemId });
  }
}