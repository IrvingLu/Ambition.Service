/************************************************************************
*本页作者    ：鲁帅
*创建日期    ：2020/11/10 9:19:29 
*功能描述    ：查询Handler
*使用说明    ：
***********************************************************************/

using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Project.Core.BaseDto;
using Project.Core.Domain;
using Project.Domain.Product;
using Project.Infrastructure.Repositories;
using Project.Web.Application.ProductApp.Commands;
using Project.Web.Application.ProductApp.Dto;
using Project.Web.Core.Extensions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Web.Appliccation.ProductApp
{
    public class ProductQueryHandler : IRequestHandler<PageProductCommand, PagedResultDto>, IRequestHandler<DetailCuustomerCommand, ProductDto>
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
        public async Task<PagedResultDto> Handle(PageProductCommand request, CancellationToken cancellationToken)
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
        public async Task<ProductDto> Handle(DetailCuustomerCommand request, CancellationToken cancellationToken)
        {
            var data = await _ProductRepository.GetByIdAsync(request.Id);
            var result = _mapper.Map<ProductDto>(data);
            return result;
        }
        #endregion

    }

}
