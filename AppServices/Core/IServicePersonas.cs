using CoreWebApp.DataTransfer.Dtos;
using CoreWebApp.DataTransfer.ModelView.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uibasoft.Community.Comunes.Result;

namespace CoreWebApp.AppServices.Core
{
    public interface IServicePersonas
    {
        Task<ResultPage<PersonaDto>> BuscarAsync(OptionSearchPersonasDto dto);
        Task<ResultOperation> EliminarAsync(PersonaDto dto);
    }
}
