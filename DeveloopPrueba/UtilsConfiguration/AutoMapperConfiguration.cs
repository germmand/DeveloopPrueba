using AutoMapper;
using DeveloopPrueba.Models;
using DeveloopPrueba.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloopPrueba.UtilsConfiguration
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(config =>
            {
                // Source -> EncargoModel
                // Destination -> EncargoModelDTO
                config.CreateMap<EncargoModel, EncargoModelDTO>()
                    .ForMember(dest => dest.EncargoId, opts => opts.MapFrom(src => src.EncargoId))
                    .ForMember(dest => dest.Albaran, opts => opts.MapFrom(src => src.Albaran))
                    .ForMember(dest => dest.Destinatario, opts => opts.MapFrom(src => src.Destinatario))
                    .ForMember(dest => dest.Direccion, opts => opts.MapFrom(src => src.Direccion))
                    .ForMember(dest => dest.Poblacion, opts => opts.MapFrom(src => src.Poblacion))
                    .ForMember(dest => dest.CP, opts => opts.MapFrom(src => src.CP))
                    .ForMember(dest => dest.Provincia, opts => opts.MapFrom(src => src.Provincia))
                    .ForMember(dest => dest.Telefono, opts => opts.MapFrom(src => src.Telefono))
                    .ForMember(dest => dest.Observaciones, opts => opts.MapFrom(src => src.Observaciones))
                    .ForMember(dest => dest.Fecha, opts => opts.MapFrom(src => src.Fecha));
                // ------------------------------------------------------------------------------------------- //

                // Source -> EncargoModelDTO
                // Destination -> EncargoModel
                config.CreateMap<EncargoModelDTO, EncargoModel>()
                    .ForMember(dest => dest.EncargoId, opts => opts.MapFrom(src => src.EncargoId))
                    .ForMember(dest => dest.Albaran, opts => opts.MapFrom(src => src.Albaran))
                    .ForMember(dest => dest.Destinatario, opts => opts.MapFrom(src => src.Destinatario))
                    .ForMember(dest => dest.Direccion, opts => opts.MapFrom(src => src.Direccion))
                    .ForMember(dest => dest.Poblacion, opts => opts.MapFrom(src => src.Poblacion))
                    .ForMember(dest => dest.CP, opts => opts.MapFrom(src => src.CP))
                    .ForMember(dest => dest.Provincia, opts => opts.MapFrom(src => src.Provincia))
                    .ForMember(dest => dest.Telefono, opts => opts.MapFrom(src => src.Telefono))
                    .ForMember(dest => dest.Observaciones, opts => opts.MapFrom(src => src.Observaciones))
                    .ForMember(dest => dest.Fecha, opts => opts.MapFrom(src => src.Fecha));
                // ------------------------------------------------------------------------------------------- //
            });
        }
    }
}