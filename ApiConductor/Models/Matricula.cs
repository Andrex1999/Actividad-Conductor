

namespace ApiConductor.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Threading.Tasks;
    public class Matricula
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string Numero { get; set; }
        
        public DateTime FechaExpedicion { get; set; }
        [Required(ErrorMessage = "Campo requerido")]

        public DateTime FechadeExpiracion { get; set; }
        [Required(ErrorMessage = "Campo requerido")]

        public bool Activo { get; set; }


    }
}
