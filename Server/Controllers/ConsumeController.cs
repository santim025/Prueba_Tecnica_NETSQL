using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prueba_Tecnica.Server.Repositories;
using Prueba_Tecnica.Shared;
using Prueba_Tecnica.Shared.DTO;

namespace Prueba_Tecnica.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsumeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private ServiceResponse response;


        public ConsumeController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        //FUncion primer ejercicio
        [HttpPost]
        [Route("historysections")]
        public async Task<ServiceResponse> HistorySections(SearchRequest request)
        {


            try
            {
                var result = _unitOfWork.CONSUMO_POR_TRAMO
                            .Find(c => c.Fecha >= request.DateInitial && c.Fecha <= request.Datefinish)
                            .GroupBy(c => c.Linea)
                            .Select(group => new
                            {
                                Line = group.Key,
                                Consumo = Math.Round(group.Sum(c => c.Residencial + c.Comercial + c.Industrial), 2),
                                Costo = Math.Round(_unitOfWork.COSTOS_POR_TRAMO
                                    .Where(cost => cost.Linea == group.Key && cost.Fecha >= request.DateInitial && cost.Fecha <= request.Datefinish)
                                    .Sum(cost => cost.Residencial + cost.Comercial + cost.Industrial), 2).ToString("N"),
                                Perdida = Math.Round(_unitOfWork.PERDIDAS_POR_TRAMO
                                    .Where(perd => perd.Linea == group.Key && perd.Fecha >= request.DateInitial && perd.Fecha <= request.Datefinish)
                                    .Average(perd => (perd.Residencial + perd.Comercial + perd.Industrial)), 4)
                            })
                            .ToList();

                return new ServiceResponse()
                {
                    IsSuccess = true,
                    Message = "Datos consultados correctamente",
                    Response = result
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse()
                {
                    IsSuccess = false,
                    Message = $"{ex.Message}",
                    Response = ""
                };
            }

        }
        //Funcion segundo ejercicio
        [HttpPost]
        [Route("consumebyclient")]
        public async Task<ServiceResponse> ConsumeByClient(SearchRequest request)
        {
            try
            {
                var result = _unitOfWork.CONSUMO_POR_TRAMO
                            .Find(c => c.Fecha >= request.DateInitial && c.Fecha <= request.Datefinish)
                            .GroupBy(c => new { c.Linea })
                            .Select(group => new ConsumptionByTypeInfo
                            {
                                Linea = group.Key.Linea,

                                ConsumoResidencial = Math.Round(group.Sum(c => c.Residencial), 2),
                                ConsumoComercial = Math.Round(group.Sum(c => c.Comercial), 2),
                                ConsumoIndustrial = Math.Round(group.Sum(c => c.Industrial), 2),

                                CostoResidencial = Math.Round(_unitOfWork.COSTOS_POR_TRAMO
                                    .Where(cost => cost.Linea == group.Key.Linea && cost.Fecha >= request.DateInitial && cost.Fecha <= request.Datefinish)
                                    .Sum(cost => cost.Residencial), 2),
                                CostoComercial = Math.Round(_unitOfWork.COSTOS_POR_TRAMO
                                    .Where(cost => cost.Linea == group.Key.Linea && cost.Fecha >= request.DateInitial && cost.Fecha <= request.Datefinish)
                                    .Sum(cost => cost.Comercial), 2),
                                CostoIndustrial = Math.Round(_unitOfWork.COSTOS_POR_TRAMO
                                    .Where(cost => cost.Linea == group.Key.Linea && cost.Fecha >= request.DateInitial && cost.Fecha <= request.Datefinish)
                                    .Sum(cost => cost.Industrial), 2),
                                PerdidaResidencial = Math.Round(_unitOfWork.PERDIDAS_POR_TRAMO
                                    .Where(perd => perd.Linea == group.Key.Linea && perd.Fecha >= request.DateInitial && perd.Fecha <= request.Datefinish)
                                    .Average(perd => perd.Residencial), 4),
                                PerdidaComercial = Math.Round(_unitOfWork.PERDIDAS_POR_TRAMO
                                    .Where(perd => perd.Linea == group.Key.Linea && perd.Fecha >= request.DateInitial && perd.Fecha <= request.Datefinish)
                                    .Average(perd => perd.Comercial), 4),
                                PerdidaIndustrial = Math.Round(_unitOfWork.PERDIDAS_POR_TRAMO
                                    .Where(perd => perd.Linea == group.Key.Linea && perd.Fecha >= request.DateInitial && perd.Fecha <= request.Datefinish)
                                    .Average(perd => perd.Industrial), 4),
                            })
                            .ToList();

                return new ServiceResponse()
                {
                    IsSuccess = true,
                    Message = "Datos consultados correctamente",
                    Response = result
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse()
                {
                    IsSuccess = false,
                    Message = $"{ex.Message}",
                    Response = ""
                };
            }

        }
        //FUncion tercer ejercicio
        [HttpPost]
        [Route("obtaintwenty")]
        public async Task<ServiceResponse> Obtain20BadLines(SearchRequest request)
        {
            try
            {
                var result = _unitOfWork.PERDIDAS_POR_TRAMO
                            .Where(perd => perd.Fecha >= request.DateInitial && perd.Fecha <= request.Datefinish)
                            .Select(perd => new TrancheClientWithLossesInfo
                            {
                                Linea = perd.Linea,
                                PérdidaTotal = Math.Round((perd.Residencial + perd.Comercial + perd.Industrial), 4),
                                Fecha = perd.Fecha.ToString("yyyy-MM-dd")
                            })
                            .OrderByDescending(x => x.PérdidaTotal)
                            .Take(20)
                            .ToList();

                return new ServiceResponse()
                {
                    IsSuccess = true,
                    Message = "Datos consultados correctamente",
                    Response = result
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse()
                {
                    IsSuccess = false,
                    Message = $"{ex.Message}",
                    Response = ""
                };
            }
        }
    }
}