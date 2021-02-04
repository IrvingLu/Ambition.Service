using AutoMapper;
using Project.Domain.Product;
using Project.Web.Application.ProductApp.Command.RequestCommandDto;
using Project.Web.Application.ProductApp.Query.ReturnDto;

namespace Project.Web.Application.ProductApp
{
    /// <summary>
    /// 功能描述    ：映射
    /// 创 建 者    ：Seven
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/1/12 9:40:56 
    /// </summary>
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
