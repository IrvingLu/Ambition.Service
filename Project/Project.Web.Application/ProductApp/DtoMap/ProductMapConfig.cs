using AutoMapper;
using Project.Infrastructure.Core.Domain;
using Project.Domain.Product;
using Project.Web.Application.ProductApp.Commands;
using Project.Web.Application.ProductApp.Dto;

namespace Project.Web.Application.ProductApp
{
    public class ProductMapConfig : Profile
    {
        public ProductMapConfig()
        {
            #region MyRegion
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();
            CreateMap<Product, ProductsDto>().ForMember(f => f.Name, option => option.MapFrom(c => c.Name + "拼接"));
            CreateMap<Product, ProductDto>();
            #endregion

        }
    }
}
