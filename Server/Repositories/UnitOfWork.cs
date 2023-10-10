using Prueba_Tecnica.Server.Data;
using Prueba_Tecnica.Shared.Models;

namespace Prueba_Tecnica.Server.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            CONSUMO_POR_TRAMO = new ConsumptionBySectionRepository(_context);
            COSTOS_POR_TRAMO = new CostsBySectionRepository(_context);
            PERDIDAS_POR_TRAMO = new LossesBySectionRepository(_context);
        }

        public IConsumptionBySectionRepository CONSUMO_POR_TRAMO { get; set; }

        public ICostsBySectionRepository COSTOS_POR_TRAMO { get; set; }

        public ILossesBySectionRepository PERDIDAS_POR_TRAMO { get; set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
