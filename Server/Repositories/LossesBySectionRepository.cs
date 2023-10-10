using Microsoft.EntityFrameworkCore;
using Prueba_Tecnica.Server.Data;
using Prueba_Tecnica.Shared.Models;
using System.Linq.Expressions;

namespace Prueba_Tecnica.Server.Repositories
{
    public class LossesBySectionRepository : Repository<PERDIDAS_POR_TRAMO>, ILossesBySectionRepository
    {
        private readonly ApplicationDbContext context;

        public LossesBySectionRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable<PERDIDAS_POR_TRAMO> Where(Expression<Func<PERDIDAS_POR_TRAMO, bool>> predicate)
        {
            return context.PERDIDAS_POR_TRAMO.Where(predicate);
        }
    }
}
