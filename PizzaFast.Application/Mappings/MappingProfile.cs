using AutoMapper;
using PizzaFast.Application.DTOs;
using PizzaFast.Domain.Models;

namespace PizzaFast.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
        }
    }
}
