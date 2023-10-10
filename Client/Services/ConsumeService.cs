using Microsoft.JSInterop;
using Prueba_Tecnica.Shared.DTO;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace Prueba_Tecnica.Client.Services
{
    public class ConsumeService : IConsumeService
    {
        private readonly HttpClient _httpClient;

        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
        }

        public ConsumeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ConsumptionPerSectionInfo>> GetAllConsumptionPerSection(SearchRequest request)
        {
            try
            {
                HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync<SearchRequest>($"api/Consume/historysections",request);
                if (responseMessage.IsSuccessStatusCode)
                {

                    try
                    {
                        string responseString = await responseMessage.Content.ReadAsStringAsync();
                        ServiceResponse response = JsonSerializer.Deserialize<ServiceResponse>(responseString);
                        if (response.IsSuccess)
                        {

                            return ((JsonElement)response.Response).Deserialize<List<ConsumptionPerSectionInfo>>();
                        }
                        else
                        {
                            return new List<ConsumptionPerSectionInfo>();
                        }
                    }
                    catch (Exception e)
                    {
                        return new List<ConsumptionPerSectionInfo>();
                    }
                }
                else
                {
                    return new List<ConsumptionPerSectionInfo>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString);
                throw;
            }
        }

        public async Task<List<ConsumptionByTypeInfo>> ConsumeByCLient(SearchRequest request)
        {
            try
            {
                HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync<SearchRequest>($"api/Consume/consumebyclient", request);
                if (responseMessage.IsSuccessStatusCode)
                {

                    try
                    {
                        string responseString = await responseMessage.Content.ReadAsStringAsync();
                        ServiceResponse response = JsonSerializer.Deserialize<ServiceResponse>(responseString);
                        if (response.IsSuccess)
                        {

                            return ((JsonElement)response.Response).Deserialize<List<ConsumptionByTypeInfo>>();
                        }
                        else
                        {
                            return new List<ConsumptionByTypeInfo>();
                        }
                    }
                    catch (Exception e)
                    {
                        return new List<ConsumptionByTypeInfo>();
                    }
                }
                else
                {
                    return new List<ConsumptionByTypeInfo>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString);
                throw;
            }
        }

        public async Task<List<TrancheClientWithLossesInfo>> ObtainTwentyBadLines(SearchRequest request)
        {
            try
            {
                HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync<SearchRequest>($"api/Consume/obtaintwenty", request);
                if (responseMessage.IsSuccessStatusCode)
                {

                    try
                    {
                        string responseString = await responseMessage.Content.ReadAsStringAsync();
                        ServiceResponse response = JsonSerializer.Deserialize<ServiceResponse>(responseString);
                        if (response.IsSuccess)
                        {

                            return ((JsonElement)response.Response).Deserialize<List<TrancheClientWithLossesInfo>>();
                        }
                        else
                        {
                            return new List<TrancheClientWithLossesInfo>();
                        }
                    }
                    catch (Exception e)
                    {
                        return new List<TrancheClientWithLossesInfo>();
                    }
                }
                else
                {
                    return new List<TrancheClientWithLossesInfo>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString);
                throw;
            }
        }
    }
}
