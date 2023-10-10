namespace Prueba_Tecnica.Server.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IConsumptionBySectionRepository CONSUMO_POR_TRAMO { get; }
        ICostsBySectionRepository COSTOS_POR_TRAMO { get; }
        ILossesBySectionRepository PERDIDAS_POR_TRAMO { get; }
        int Complete();
    }
}
