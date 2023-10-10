using Microsoft.EntityFrameworkCore;
using Prueba_Tecnica.Shared.Models;

namespace Prueba_Tecnica.Server.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }

        public DbSet<CONSUMO_POR_TRAMO> CONSUMO_POR_TRAMO { get; set; }
        public DbSet<COSTOS_POR_TRAMO> COSTOS_POR_TRAMO { get; set; }
        public DbSet<PERDIDAS_POR_TRAMO> PERDIDAS_POR_TRAMO { get; set; }
    }
}
