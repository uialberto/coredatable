using AutoMapper;
using CoreWebApp.DataTransfer.Dtos;
using CoreWebApp.Entities;
using CoreWebApp.Helpers;
using CoreWebApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApp.DataAccess.Helpers
{
    public class BaseProfile : Profile
    {
        public BaseProfile()
        {
            CreateMap<Persona, PersonaViewModel>()
                .ForMember(dest => dest.Codigo, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.NombreCompleto, opts => opts.MapFrom(src => $"{src.Nombres} {src.Apellidos}"))
                .ForMember(dest => dest.Cargo, opts => opts.MapFrom(src => EnumHelper<Position>.GetDisplayValue(src.Cargo)))
                .ForMember(dest => dest.Nombres, opts => opts.MapFrom(src => src.Nombres))
                .ForMember(dest => dest.Apellidos, opts => opts.MapFrom(src => src.Apellidos))
                .ForMember(dest => dest.Oficina, opts => opts.MapFrom(src => src.Oficina))
                .ForMember(dest => dest.FechaInicio, opts => opts.MapFrom(src => src.FechaInicio))
                .ForMember(dest => dest.Experiencia, opts => opts.MapFrom(src => src.Experiencia))
                .ReverseMap()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Codigo));

            CreateMap<PersonaDto, PersonaViewModel>()
                .ForMember(dest => dest.Codigo, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.NombreCompleto, opts => opts.MapFrom(src => $"{src.Nombres} {src.Apellidos}"))
                .ForMember(dest => dest.Cargo, opts => opts.MapFrom(src => EnumHelper<Position>.GetDisplayValue(src.Cargo)))
                .ForMember(dest => dest.Nombres, opts => opts.MapFrom(src => src.Nombres))
                .ForMember(dest => dest.Apellidos, opts => opts.MapFrom(src => src.Apellidos))
                .ForMember(dest => dest.Oficina, opts => opts.MapFrom(src => src.Oficina))
                .ForMember(dest => dest.FechaInicio, opts => opts.MapFrom(src => src.FechaInicio))
                .ForMember(dest => dest.Experiencia, opts => opts.MapFrom(src => src.Experiencia))
                .ReverseMap()               
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Codigo));

            CreateMap<Persona, PersonaDto>()
                .ReverseMap();

        }
    }
}
