using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Photon.Data.Configuration;

public static class EntityTypeBuilderExtensions
{
  public static List<PropertyBuilder> Properties<T>(this EntityTypeBuilder<T> builder,
    Func<PropertyInfo, bool>? filter = null) where T : class
  {
    var props = typeof(T).GetProperties().AsEnumerable();
    if (filter != null)
    {
      props = props.Where(filter);
    }
    return props.Select(x => builder.Property(x.PropertyType, x.Name))
      .ToList();
  }
}