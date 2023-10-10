using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Shared.DTO
{
    public class ConsumptionPerSectionInfo
    {
        [JsonPropertyName("line")]
        public string Line { get; set; }
        [JsonPropertyName("consumo")]
        public double Consumo { get; set; }
        [JsonPropertyName("costo")]
        public string Costo { get; set; }
        [JsonPropertyName("perdida")]
        public double Perdida { get; set; }

        public ConsumptionPerSectionInfo()
        {
            Line = "";
            Consumo = 0;
            Costo = "";
            Perdida = 0;
        }
    }
}
