using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApp.DataTransfer.ModelView.Home
{
    public enum PersonaOrderColumn
    {
        Codigo,
        Nombres,
        Apellidos,
        Oficina
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
