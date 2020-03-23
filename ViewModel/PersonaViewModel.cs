using CoreWebApp.Entities;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApp.ViewModel
{
    public class PersonaViewModel
    {
        [JqueryDataTableColumn(Order = 1)]
        public long Id { get; set; }
        [JqueryDataTableColumn(Order = 2)]
        [SearchableString(EntityProperty = "Nombres,Apellidos")]
        [Sortable(EntityProperty = "Nombres,Apellidos", Default = true)]
        public string NombreCompleto { get; set; }
        [JqueryDataTableColumn(Exclude = true)]
        public string Nombres { get; set; }
        [JqueryDataTableColumn(Exclude = true)]
        public string Apellidos { get; set; }
        [JqueryDataTableColumn(Order = 3)]
        [SearchableEnum(typeof(Position))]
        [Sortable]
        public Position Cargo { get; set; }
        [Display(Name = "Oficina")]
        [JqueryDataTableColumn(Order = 4)]
        [SearchableString(EntityProperty = "Oficina")]
        [Sortable(EntityProperty = "Oficina")]
        public string Oficina { get; set; }
        [JqueryDataTableColumn(Order = 5)]
        [SearchableShort]
        [Sortable]
        public short? Experiencia { get; set; }
        [DisplayName("Fecha")]
        [JqueryDataTableColumn(Order = 6)]
        [SearchableDateTime(EntityProperty = "FechaInicio")]
        [Sortable(EntityProperty = "FechaInicio")]
        public DateTime? FechaInicio { get; set; }
        [JqueryDataTableColumn(Order = 7)]
        [SearchableLong]
        [Sortable]
        public decimal? Salario { get; set; }
        [JqueryDataTableColumn(Order = 8)]
        public string Action { get; set; }
    }
}
