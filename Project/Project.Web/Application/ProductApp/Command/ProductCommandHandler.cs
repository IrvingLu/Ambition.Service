using AutoMapper;
using MediatR;
using Project.Domain.Product;
using Project.Infrastructure.Repositories;
using Project.Web.Application.ProductApp.Command.RequestCommandDto;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Web.Application.ProductApp
{
    /// <summary>
    /// 功能描述    ：命令
    /// 创 建 者    ：Seven
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/1/12 9:40:56 
    /// </summary>
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
