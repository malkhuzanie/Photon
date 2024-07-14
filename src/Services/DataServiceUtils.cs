using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Photon.Data;
namespace Photon.Services
{
    public static class DataServiceUtils
    {
        public static async Task<bool> RecordExists<TEntity>(this PhotonContext context, Expression<Func<TEntity, bool>> predicate)
            where TEntity : class
        {
            return await context.Set<TEntity>().SingleOrDefaultAsync(predicate) is not null;
        }
    }
}
