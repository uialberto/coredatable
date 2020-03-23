using JqueryDataTables.ServerSide.AspNetCoreWeb.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApp.DataTransfer.ModelView.Home.Result
{
    public class PersonaResult
    {
        [JqueryDataTableColumn(Order = 1)]
        public string Codigo { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Oficina { get; set; }
        public short? Experiencia { get; set; }
        public DateTime? FechaInicio { get; set; }
        public decimal? Salario { get; set; }
        public string Action { get; set; }
    }
}
