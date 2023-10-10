using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Shared.DTO
{
    public class ServiceResponse
    {
        [JsonPropertyName("msg")]
        public string Message { get; set; }
        [JsonPropertyName("success")]
        public bool IsSuccess { get; set; }
        [JsonPropertyName("response")]
        public Object Response { get; set; }
    }
}
