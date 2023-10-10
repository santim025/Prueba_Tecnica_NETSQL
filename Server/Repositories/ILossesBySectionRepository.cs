using Prueba_Tecnica.Shared.Models;
using System.Linq.Expressions;

namespace Prueba_Tecnica.Server.Repositories
{
    public interface ILossesBySectionRepository : IRepository<PERDIDAS_POR_TRAMO>
    {
        IQueryable<PERDIDAS_POR_TRAMO> Where(Expression<Func<PERDIDAS_POR_TRAMO, bool>> predicate);
    }
}
