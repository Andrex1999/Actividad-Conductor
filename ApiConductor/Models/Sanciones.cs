

namespace ApiConductor.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Threading.Tasks;
    public class Sanciones
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime FechaActual { get; set; }
        [Required(ErrorMessage = "Campo requerido")]

        public string ConductorId { get; set; }
        [ForeignKey("Identificacion")]
        public virtual Conductor COnductor { get; set; }


        public string Sancion { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(100, ErrorMessage = "Longitud máxima 100 caracteres")]

        public string Observacion { get; set; }
        [Required(ErrorMessage = "Campo requerido")]

        public double Valor { get; set; }
        


    }
}
