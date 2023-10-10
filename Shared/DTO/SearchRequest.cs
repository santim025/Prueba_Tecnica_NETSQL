using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Shared.DTO
{
    public class SearchRequest
    {
        [JsonPropertyName("dateinitial")]
        public DateTime DateInitial { get; set; }
        [JsonPropertyName("datefinish")]
        public DateTime Datefinish { get; set; }
    }
}
