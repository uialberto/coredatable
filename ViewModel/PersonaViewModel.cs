using CoreWebApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApp.ViewModel
{
    public class PersonaViewModel
    {       
        public long Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public Position Cargo { get; set; }
        public string Oficina { get; set; }
        public short? Experiencia { get; set; }
        public DateTime? FechaInicio { get; set; }
        public decimal? Salario { get; set; }
    }
}
