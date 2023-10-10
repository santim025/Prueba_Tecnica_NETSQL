using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Shared.DTO
{
    public class TrancheClientWithLossesInfo
    {
        [JsonPropertyName("line")]
        public string Linea { get; set; }
        [JsonPropertyName("losstotal")]
        public double PérdidaTotal { get; set; }
        [JsonPropertyName("date")]
        public string Fecha { get; set; }
    }
}
