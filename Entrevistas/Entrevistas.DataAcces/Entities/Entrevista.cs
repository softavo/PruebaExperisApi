using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entrevistas.DataAccess.Entities
{
    public class Entrevista
    {
        public int Id { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        [Required]
        public string NombresCompletos { get; set; }
        [Required]
        public string ModalidadEntrevista { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public string Hora { get; set; }
    }
}
