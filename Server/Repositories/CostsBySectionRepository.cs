using Microsoft.EntityFrameworkCore;
using Prueba_Tecnica.Server.Data;
using Prueba_Tecnica.Shared.Models;
using System.Linq.Expressions;

namespace Prueba_Tecnica.Server.Repositories
{
    public class CostsBySectionRepository : Repository<COSTOS_POR_TRAMO>, ICostsBySectionRepository
    {
        private readonly ApplicationDbContext context;

        public CostsBySectionRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable<COSTOS_POR_TRAMO> Where(Expression<Func<COSTOS_POR_TRAMO, bool>> predicate)
        {
            return context.COSTOS_POR_TRAMO.Where(predicate);
        }
    }
}
