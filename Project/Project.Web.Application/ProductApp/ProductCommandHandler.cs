/************************************************************************
*本页作者    ：鲁帅
*创建日期    ：2020/11/10 9:19:29 
*功能描述    ：命令Handler
*使用说明    ：
***********************************************************************/

using AutoMapper;
using MediatR;
using Project.Infrastructure.Core.Domain;
using Project.Domain.Product;
using Project.Infrastructure.Repositories;
using Project.Web.Application.ProductApp.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Web.Application.ProductApp
{
    public class ProductCommandHandler : IRequestHandler<CreateProductCommand, Unit>, IRequestHandler<UpdateProductCommand, Unit>, IRequestHandler<DeleteProductCommand, Unit>
    {
        #region Fileds
        private readonly IRepository<Product> _ProductRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public ProductCommandHandler(IRepository<Product> ProductRepository, IMapper mapper)
        {
            _ProductRepository = ProductRepository;
            _mapper = mapper;
        } 
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<Product>(request);
            await _ProductRepository.InsertAsync(result);
            return new Unit();
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<Product>(request);
            await _ProductRepository.UpdateAsync(result);
            return new Unit();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var result = await _ProductRepository.GetByIdAsync(request.Id);
            await _ProductRepository.DeleteAsync(result);
            return new Unit();
        }



        #endregion
    }
}
