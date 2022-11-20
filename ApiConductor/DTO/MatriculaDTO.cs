using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiConductor.DTO
{
    public class MatriculaDTO
    {
        public int Id { get; set; }
 
        public string Numero { get; set; }
 
        public DateTime FechaExpedicion { get; set; }

        public DateTime FechadeExpiracion { get; set; }

        public bool Activo { get; set; }
    }
}
