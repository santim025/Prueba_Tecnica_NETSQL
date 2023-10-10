using Prueba_Tecnica.Shared.DTO;

namespace Prueba_Tecnica.Client.Services
{
    public interface IConsumeService
    {
        string ErrorMessage
        {
            get;
        }

        Task<List<ConsumptionPerSectionInfo>> GetAllConsumptionPerSection(SearchRequest request);
        Task<List<ConsumptionByTypeInfo>> ConsumeByCLient(SearchRequest request);
        Task<List<TrancheClientWithLossesInfo>> ObtainTwentyBadLines(SearchRequest request);
    }
}
