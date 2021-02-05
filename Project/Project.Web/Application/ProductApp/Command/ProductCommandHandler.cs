using AutoMapper;
using MediatR;
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

        private readonly IUnitRepository<Product> _ProductRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        #endregion

        #region Ctor
        public ProductCommandHandler(IUnitRepository<Product> ProductRepository, IMapper mapper, IUnitOfWork unitOfWork, IMediator mediator)
        {
            _ProductRepository = ProductRepository;
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
            var data = new Product(request.Name);

            await _mediator.DispatchDomainEventsAsync(data);
            //using (_unitOfWork)
            //{
            //    _unitOfWork.Begin();
            //    await _ProductRepository.AddAsync(data);
            //    await _unitOfWork.CommitAsync();
            //}
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
            //var result = await _ProductRepository.GetByIdAsync(request.Id);
            //await _ProductRepository.DeleteAsync(result);
            return new Unit();
        }



    }
}
