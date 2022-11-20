using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiConductor.DTO
{
    public class SancionesDTO
    {

        public int Id { get; set; }
        public DateTime FechaActual { get; set; }
        public string ConductorId { get; set; }
        
        public string Sancion { get; set; }

        public string Observacion { get; set; }

        public double Valor { get; set; }

    }
}
