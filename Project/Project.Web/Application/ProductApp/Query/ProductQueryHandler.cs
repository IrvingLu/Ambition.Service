/************************************************************************
*本页作者    ：鲁帅
*创建日期    ：2020/11/10 9:19:29 
*功能描述    ：查询Handler
*使用说明    ：
***********************************************************************/

using AutoMapper;
using MediatR;
using Project.Core.BaseDto;
using Project.Domain.Product;
using Project.Infrastructure.Repositories;
using Project.Web.Application.ProductApp.Dto;
using Project.Web.Application.ProductApp.Query.Commands;
using Project.Web.Application.ProductApp.Query.RequestCommandDto;
using Project.Web.Application.ProductApp.Query.ReturnDto;
using Project.Web.Core.Extensions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Web.Appliccation.ProductApp
{
    /// <summary>
    /// 功能描述    ：查询逻辑方法
    /// 创 建 者    ：Seven
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/1/12 9:40:56 
    /// </summary>
    public class ProductQueryHandler : IRequestHandler<ProductsCommand, PagedResultDto>, IRequestHandler<ProductCommand, ProductDto>
    {
        #region Fileds
        private readonly IRepository<Product> _ProductRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public ProductQueryHandler(IRepository<Product> ProductRepository, IMapper mapper)
        {
            _ProductRepository = ProductRepository;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        /// <summary>
        /// 获取所有
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<PagedResultDto> Handle(ProductsCommand request, CancellationToken cancellationToken)
        {
            var query = _ProductRepository.TableNoTracking;
            var pageResult = await query.ToPageListAsync(request.PageIndex, request.PageSize);
            pageResult.Data = _mapper.Map<List<ProductsDto>>(pageResult.Data);
            return pageResult;
        }
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ProductDto> Handle(ProductCommand request, CancellationToken cancellationToken)
        {
            var data = await _ProductRepository.GetByIdAsync(request.Id);
            var result = _mapper.Map<ProductDto>(data);
            return result;
        }
        #endregion

    }

}
