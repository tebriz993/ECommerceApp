using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tech.BusinessLogic.Dtos;
using Tech.Entity.Concrete.Products;

namespace Tech.BusinessLogic.Mappers
{
    internal class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductViewDto>()
                .ForMember(s => s.Category, y => y.MapFrom(x => x.Category.Name));

            CreateMap<ProductAddDto, Product>().ReverseMap();

            CreateMap<Category, CategoryListDto>();


     
        }
    }
}
