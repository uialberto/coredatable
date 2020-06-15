using JqueryDataTables.ServerSide.AspNetCoreWeb.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApp.DataTransfer.ModelView.Home.Result
{
    public class PersonaExcelResult
    {
        [Display(Name = "Codigo")]
        public long Id { get; set; }
        //[DisplayName("Nombres")]
        public string Nombres { get; set; }
        //[DisplayName("Apellidos")]
        public string Apellidos { get; set; }
        //[DisplayName("Oficina")]
        public string Oficina { get; set; }
        public short? Experiencia { get; set; }
        [DisplayName("Fecha Inicio")]
        public DateTime? FechaInicio { get; set; }

        [DisplayName("Salario")]
        //[DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public decimal? Salario { get; set; }

    }
}
