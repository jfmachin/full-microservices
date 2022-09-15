using AutoMapper;
using Products.API.Models.DTOs;
using Products.API.Models.Entities;

namespace Products.API.Mappings {
    public class MappingProfile : Profile {
        public MappingProfile() {
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
