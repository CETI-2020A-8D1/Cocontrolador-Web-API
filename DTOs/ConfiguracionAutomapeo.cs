using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CocontroladorAPI.Models;

namespace CocontroladorAPI.DTOs
{
    public class ConfiguracionAutomapeo
    {
        public static void Configurar()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CatCategorias, CatCategoriasDTO>()
                   .ForMember(x => x.MtoCatLibros, o => o.Ignore())
                   //.ForMember(x => x.Nombre, o => o.MapFrom(s => s.FirstName))
                   .ReverseMap();

                cfg.CreateMap<CatEditorial, CatEditorialDTO>()
                   .ForMember(x => x.MtoCatLibros, o => o.Ignore())
                   .ReverseMap();

                cfg.CreateMap<CatPaises, CatPaisesDTO>()
                   .ForMember(x => x.MtoCatLibros, o => o.Ignore())
                   .ReverseMap();

                cfg.CreateMap<MtoCatCliente, MtoCatClienteDTO>()
                   .ForMember(x => x.TraCompras, o => o.Ignore())
                   .ReverseMap();

                cfg.CreateMap<MtoCatLibros, MtoCatLibrosDTO>()
                   .ForMember(x => x.TraConceptoCompra, o => o.Ignore())
                   .ReverseMap();

                cfg.CreateMap<TraCompras, TraComprasDTO>()
                   .ForMember(x => x.TraConceptoCompra, o => o.Ignore())
                   .ReverseMap();

                cfg.CreateMap<TraConceptoCompra, TraConceptoCompraDTO>()
                  .ReverseMap();
            });
        }
    }
}
