using Prueba_Tecnica.Shared.Models;
using System.Linq.Expressions;

namespace Prueba_Tecnica.Server.Repositories
{
    public interface ICostsBySectionRepository : IRepository<COSTOS_POR_TRAMO>
    {
        IQueryable<COSTOS_POR_TRAMO> Where(Expression<Func<COSTOS_POR_TRAMO, bool>> predicate);
    }
}
