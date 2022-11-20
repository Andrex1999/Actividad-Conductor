

namespace ApiConductor.Models
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Threading.Tasks;
    public class Conductor
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        
        
        public string Identificacion {get;set;}
        [StringLength(15, ErrorMessage = "Longitud máxima 15 caracteres")]

        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(20, ErrorMessage = "Longitud máxima 20 caracteres")]

        public string Direccion { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(30, ErrorMessage = "Longitud máxima 30 caracteres")]

        public string Telefono { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(15, ErrorMessage = "Longitud máxima 15 caracteres")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(30, ErrorMessage = "Longitud máxima 30 caracteres")]

        public DateTime FechaNacimiento { get; set; }
        [Required(ErrorMessage = "Campo requerido")]

        public bool Activo { get; set; }
        [Required(ErrorMessage = "Campo requerido")]


        public int MatriculaId { get; set; }
        [ForeignKey("MatriculaId")]

        public virtual Matricula MAtricula { get; set; }


    }
}
