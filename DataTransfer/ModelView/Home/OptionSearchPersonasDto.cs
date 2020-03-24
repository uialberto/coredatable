using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApp.DataTransfer.ModelView.Home
{
    public enum PersonaOrderColumn
    {
        Codigo = 0,
        Nombres = 1,
        Apellidos = 2,
        Cargo = 3,
        Oficina = 4,
        Experiencia = 5,
        FechaInicio = 6,
        Salario = 7
    }
    public class OptionSearchPersonasDto
    {
        public string TextSearch { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public PersonaOrderColumn OrderBy { get; set; }
        public bool IsAscending { get; set; }
    }
}
