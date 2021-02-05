using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Project.Domain.Abstractions;
using Project.Domain.Product;
using Project.Infrastructure.EntityFrameworkCore;
using Project.Infrastructure.Extensions;
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

        private readonly IUnitRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        #endregion

        #region Ctor
        public ProductCommandHandler(IUnitRepository<Product> productRepository, IMapper mapper, IUnitOfWork unitOfWork, IMediator mediator)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _mediator = mediator;

        }

        #endregion
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            //var result = _mapper.Map<Product>(request);
            var ss = await _productRepository.TableNoTracking.ToListAsync();
            var data = new Product(request.Name);
            await _productRepository.AddAsync(data);
            await _productRepository.UnitOfWork.SaveEntitiesAsync();
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
            await _productRepository.UpdateAsync(result);
            await _productRepository.UnitOfWork.SaveEntitiesAsync();
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
            //var result = await _ProductRepository.GetByIdAsync(request.Id);
            //await _ProductRepository.DeleteAsync(result);
            return new Unit();
        }



    }
}
