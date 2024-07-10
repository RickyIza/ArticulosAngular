using AutoMapper;
using Sol.Galaxy.Data.Entities;
using Sol.Galaxy.Data.Entities.Utils;
using Sol.Galaxy.Domain;
using Sol.Galaxy.Domain.Utils;

namespace Sol.Galaxy.MinimalApi.Helpers
{
    public class AutomapperHelper : Profile
    {
        public AutomapperHelper()
        {

            CreateMap<Cliente, Customer>()
                .ForMember(t => t.CustomerId, opt => opt.MapFrom(o => o.IdCliente))
                .ForMember(t => t.FirstName, opt => opt.MapFrom(o => o.Nombres))
                .ForMember(t => t.LastName, opt => opt.MapFrom(o => o.Apellidos))
                .ForMember(t => t.CustomerTypeId, opt => opt.MapFrom(o => o.TipoCliente))
                .ReverseMap();

            CreateMap<Customer, ClienteLista>()
             .ForMember(dest => dest.IdCliente, opt => opt.MapFrom(src => src.CustomerId))
             .ForMember(dest => dest.NombreCompleto, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
             .ForMember(dest => dest.TipoCliente, opt => opt.MapFrom(src => src.CustomerTypeId))
             .ForMember(dest => dest.TipoClienteDesc, opt => opt.MapFrom(src => src.CustomerType != null ? src.CustomerType.Description : string.Empty));

            CreateMap<Option, Opcion>()
                .ForMember(t => t.Titulo, opt => opt.MapFrom(o => o.Title))
                .ForMember(t => t.Url, opt => opt.MapFrom(o => o.Url))
                .ForMember(t => t.Codigo, opt => opt.MapFrom(o => o.OptionId))
                .ReverseMap();

            CreateMap<Articulo, Product>()
                .ForMember(t => t.ProductId, opt => opt.MapFrom(o => o.Codigo))
                .ForMember(t => t.ProductName, opt => opt.MapFrom(o => o.Nombre))
                .ForMember(t => t.Price, opt => opt.MapFrom(o => o.Precio))
                .ForMember(t => t.Stock, opt => opt.MapFrom(o => o.Stock))
                .ForMember(t => t.Cost, opt => opt.MapFrom(o => o.Costo))
                .ReverseMap()
                ;

            CreateMap<ArticuloLista, Product>()
              .ForMember(t => t.ProductId, opt => opt.MapFrom(o => o.Codigo))
              .ForMember(t => t.ProductName, opt => opt.MapFrom(o => o.Nombre))
              .ForMember(t => t.Price, opt => opt.MapFrom(o => o.Precio))
              .ForMember(t => t.Stock, opt => opt.MapFrom(o => o.Stock))
              .ReverseMap()
          ;

            CreateMap(typeof(ListaPaginada<>), typeof(PaginatedList<>))

                .ForMember("PageIndex", opt => opt.MapFrom("NroPagina"))
                .ForMember("PageSize", opt => opt.MapFrom("RegPagina"))
                .ForMember("TotalRows", opt => opt.MapFrom("TotalRegistros"))
                .ForMember("Items", opt => opt.MapFrom("Registros"))
                .ReverseMap();
        }

    }
}
