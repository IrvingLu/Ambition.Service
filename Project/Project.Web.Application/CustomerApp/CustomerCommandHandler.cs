/************************************************************************
*本页作者    ：鲁帅
*创建日期    ：2020/11/10 9:19:29 
*功能描述    ：命令Handler
*使用说明    ：
***********************************************************************/

using AutoMapper;
using MediatR;
using Project.Core.Domain;
using Project.Infrastructure.Repositories;
using Project.Web.Application.CustomerApp.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Web.Application.CustomerApp
{
    public class CustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Unit>, IRequestHandler<UpdateCustomerCommand, Unit>, IRequestHandler<DeleteCustomerCommand, Unit>
    {
        #region Fileds
        private readonly IRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public CustomerCommandHandler(IRepository<Customer> customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        } 
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<Customer>(request);
            await _customerRepository.InsertAsync(result);
            return new Unit();
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<Customer>(request);
            await _customerRepository.UpdateAsync(result);
            return new Unit();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var result = await _customerRepository.GetByIdAsync(request.Id);
            await _customerRepository.DeleteAsync(result);
            return new Unit();
        }



        #endregion
    }
}
