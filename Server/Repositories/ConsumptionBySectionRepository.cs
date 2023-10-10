using Prueba_Tecnica.Server.Data;
using Prueba_Tecnica.Shared.Models;

namespace Prueba_Tecnica.Server.Repositories
{
    public class ConsumptionBySectionRepository : Repository<CONSUMO_POR_TRAMO>, IConsumptionBySectionRepository
    {
        private readonly ApplicationDbContext context;

        public ConsumptionBySectionRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
