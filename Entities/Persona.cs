using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApp.Entities
{
    
    public class Persona
    {
        [Key]
        public long Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public Position Cargo { get; set; }
        public string Oficina { get; set; }
        public short? Experiencia { get; set; }        
        public DateTime? FechaInicio { get; set; }
        public decimal? Salario { get; set; }
    }
}
