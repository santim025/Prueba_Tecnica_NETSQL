using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Shared.DTO
{
    public class ConsumptionByTypeInfo
    {
        [JsonPropertyName("line")]
        public string Linea { get; set; }
        [JsonPropertyName("consumeresidential")]
        public double ConsumoResidencial { get; set; }
        [JsonPropertyName("consumecommercial")]
        public double ConsumoComercial { get; set; }
        [JsonPropertyName("consumeindustrial")]
        public double ConsumoIndustrial { get; set; }
        [JsonPropertyName("costresidencial")]
        public double CostoResidencial { get; set; }
        [JsonPropertyName("costcommercial")]
        public double CostoComercial { get; set; }
        [JsonPropertyName("costindustrial")]
        public double CostoIndustrial { get; set; }
        [JsonPropertyName("lossresidential")]
        public double PerdidaResidencial { get; set; }
        [JsonPropertyName("losscommercial")]
        public double PerdidaComercial { get; set; }
        [JsonPropertyName("lossindustrial")]
        public double PerdidaIndustrial { get; set; }
    }
}
