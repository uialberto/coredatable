using AutoMapper;
using AutoMapper.QueryableExtensions;
using CoreWebApp.DataAccess.UnitOfWork;
using CoreWebApp.DataTransfer.Dtos;
using CoreWebApp.DataTransfer.ModelView.Home;
using CoreWebApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Uibasoft.Community.Comunes.Extensions;
using Uibasoft.Community.Comunes.Result;

namespace CoreWebApp.AppServices.Core.Impl
{
    public class ServicePersonas : IServicePersonas
    {
        private readonly AppUnitOfWork _uow;
        private readonly IConfigurationProvider _mapperConfig;

        public ServicePersonas(AppUnitOfWork pUoW, IConfigurationProvider pMapperConfig)
        {
            _uow = pUoW;
            _mapperConfig = pMapperConfig;
        }

        public async Task<ResultPage<PersonaDto>> Buscar(OptionSearchPersonasDto dto)
        {
            var result = new ResultPage<PersonaDto>();
            var totales = _uow.Personas.Count();
            var totalFiltered = 0;
            
            #region Filtro

            Expression<Func<Persona, bool>> filter = ele => true;

            if (!string.IsNullOrWhiteSpace(dto.TextSearch))
            {
                filter = filter.And(ele => ele.Id.ToString().Contains(dto.TextSearch.ToLower()) ||
                                                ele.Nombres.ToLower().Contains(dto.TextSearch.ToLower()) ||
                                                ele.Apellidos.ToLower().Contains(dto.TextSearch.ToLower())||
                                                ele.Oficina.ToLower().Contains(dto.TextSearch.ToLower()));
            }

            var query = _uow.Personas.Where(filter).ProjectTo<PersonaDto>(_mapperConfig).ToListAsync();
            
            IList<PersonaDto> list = await query;

            totalFiltered = list.Count;

            #endregion

            #region Ordenacion

            switch (dto.OrderBy)
            {
                case PersonaOrderColumn.Codigo:
                    {
                        list = dto.IsAscending ? list.OrderBy(ele => ele.Id).ThenBy(ele => ele.Id).ToList()
                            : list.OrderByDescending(ele => ele.Id).ThenBy(ele => ele.Id).ToList();
                    }
                    break;
                case PersonaOrderColumn.Nombres:
                    {
                        list = dto.IsAscending ? list.OrderBy(ele => ele.Nombres).ThenBy(ele => ele.Nombres).ToList()
                            : list.OrderByDescending(ele => ele.Nombres).ThenBy(ele => ele.Nombres).ToList();
                    }
                    break;
                case PersonaOrderColumn.Apellidos:
                    {
                        list = dto.IsAscending ? list.OrderBy(ele => ele.Apellidos).ThenBy(ele => ele.Apellidos).ToList()
                           : list.OrderByDescending(ele => ele.Apellidos).ThenBy(ele => ele.Apellidos).ToList();
                    }
                    break;
                case PersonaOrderColumn.Oficina:
                    {
                        list = dto.IsAscending ? list.OrderBy(ele => ele.Oficina).ThenBy(ele => ele.Oficina).ToList()
                           : list.OrderByDescending(ele => ele.Oficina).ThenBy(ele => ele.Oficina).ToList();
                    }
                    break;
                default:
                    {
                        list = dto.IsAscending ? list.OrderBy(ele => ele.Id).ThenBy(ele => ele.Id).ToList()
                          : list.OrderByDescending(ele => ele.Id).ThenBy(ele => ele.Id).ToList();
                    }
                    break;
            }


            #endregion

            #region Paginacion

            var pageIndex = dto.PageIndex;
            var pageSize = dto.PageSize;

            if (pageIndex < 1) pageIndex = 1;
            if (pageSize < 1) pageSize = 1;

            result.PageIndex = pageIndex;
            result.PageSize = pageSize;

            list = list.Skip((pageIndex - 1) * pageSize)
                       .Take(pageSize).ToList();

            #endregion

            result.Elements = list.ToList();
            result.TotalElements = totales;
            result.TotalPage = (result.TotalElements / result.PageSize) + (result.TotalElements % result.PageSize == 0 ? 0 : 1);
            result.TotalFiltered = totalFiltered;

            return result;
        }
    }
}
