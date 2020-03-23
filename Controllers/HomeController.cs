﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoreWebApp.Models;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Models;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using AutoMapper;
using CoreWebApp.AppServices.Core;
using CoreWebApp.DataTransfer.ModelView.Home;
using CoreWebApp.DataTransfer.Dtos;
using System.Data.SqlClient;
using CoreWebApp.DataTransfer.ModelView.Home.Result;
using CoreWebApp.ViewModel;

namespace CoreWebApp.Controllers
{   
    public class HomeController : Controller
    {
        private readonly IServicePersonas _service;
        private readonly IMapper _mapper;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IServicePersonas pService, IMapper pMapper)
        {
            _logger = logger;
            _service = pService;
            _mapper = pMapper;
        }

        public IActionResult Index()
        {
            return View(new PersonaViewModel());
        }
        
        [HttpPost]
        public async Task<IActionResult> SearchPersonas([FromBody]JqueryDataTablesParameters param)
        {
            try
            {
                HttpContext.Session.SetString(nameof(JqueryDataTablesParameters), JsonSerializer.Serialize(param));

                #region Paginacion y Ordenacion

                var pageIndex = (param.Start / param.Length) + 1;
                var pageSize = param.Length;
                var sortedColumns = param.Columns;
                var colum = sortedColumns.FirstOrDefault();
                var orderBy = PersonaOrderColumn.Codigo;
                var orderIsAscending = true;                
                if (colum != null)
                {
                    var dataColum = colum.Data;

                    switch (dataColum)
                    {
                        case "Codigo":
                            {
                                orderBy = PersonaOrderColumn.Codigo;
                            }
                            break;
                        case "Nombres":
                            {
                                orderBy = PersonaOrderColumn.Nombres;
                            }
                            break;
                        case "Apellidos":
                            {
                                orderBy = PersonaOrderColumn.Apellidos;
                            }
                            break;
                        case "Oficina":
                            {
                                orderBy = PersonaOrderColumn.Oficina;
                            }
                            break;
                    }
                    orderIsAscending = true;
                    //sucOrderDir = param.SortOrder == Column.OrderDirection.Ascendant ? true : false;//SortOrder.Ascending : SortOrder.Descending;
                }

                #endregion

                var optionSearch = new OptionSearchPersonasDto
                {
                    TextSearch = param.Search?.Value,
                    PageIndex = pageIndex,
                    IsAscending = orderIsAscending,
                    PageSize = pageSize,
                    OrderBy = orderBy,                    
                };

                var res = await _service.Buscar(optionSearch);
                
                if (res.HasErrors)
                {
                    return null;
                }

                var list = res.Elements;

                var data = list.Select(ele => new PersonaViewModel
                {
                    Codigo = ele.Id.ToString(),
                    Nombres = ele.Nombres,
                    Apellidos = ele.Apellidos,
                    Oficina = ele.Oficina,
                    Experiencia = ele.Experiencia,
                    FechaInicio = ele.FechaInicio,
                    Salario = ele.Salario,
                    Cargo = ele.Cargo
                }).ToList();

                var recordsFiltered = res.TotalFiltered;
                var recordsTotal = res.TotalElements;

                return new JsonResult(new JqueryDataTablesResult<PersonaViewModel>
                {
                    Draw = param.Draw,
                    Data = data,
                    RecordsFiltered = recordsFiltered,
                    RecordsTotal = recordsTotal
                });


            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return new JsonResult(new { error = "Internal Server Error" });
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
