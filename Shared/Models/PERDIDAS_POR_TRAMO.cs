using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Shared.Models
{
    public class PERDIDAS_POR_TRAMO
    {
        public int ID { get; set; }
        public string Linea { get; set; }
        public DateTime Fecha { get; set; }
        public double Residencial { get; set; }
        public double Comercial { get; set; }
        public double Industrial { get; set; }
    }
}
