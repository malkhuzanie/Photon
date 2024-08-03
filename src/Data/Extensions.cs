using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Photon.Data;

public static class Extensions
{
  public static void CreateDbIfNotExists(this IHost host)
  {
    using (var scope = host.Services.CreateScope())
    {
      var services = scope.ServiceProvider;
      var context = services.GetRequiredService<PhotonContext>();
      context.Database.EnsureCreated();
      DbInitialiser.Initialise(context);
    }
  }

  // Add an element to a database table if the result of predicate (TKey)
  // doesn't already exist
  public static async Task<EntityEntry<T>?> AddIfNotExists<T>(this DbSet<T> set, T entity,
    Expression<Func<T, bool>>? predicate = null)
    where T : class
  {
    return (predicate != null && set.Any(predicate)) ? null : await set.AddAsync(entity);
  }

  // Add range of elements to a database table if the result of predicate (TKey)
  // doesn't already exist
  public static async Task AddRangeIfNotExists<T, TKey>(this DbSet<T> set, 
    Func<T, TKey> predicate,
    params T[] entities)
    where T : class
  {
    var existing = set.Select(predicate).ToHashSet();
    await set.AddRangeAsync(entities.Where(e => !existing.Contains(predicate(e))));
  }
}
