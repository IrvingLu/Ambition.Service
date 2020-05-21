/// ***********************************************************************
///
/// =================================
/// CLR版本    ：4.0.30319.42000
/// 命名空间    ：Sfan.Service
/// 文件名称    ：CreateSfanCommandHandler.cs
/// =================================
/// 创 建 者    ：鲁岩奇
/// 创建日期    ：2019/12/4 11:14:39 
/// 功能描述    ：
/// 使用说明    ：
/// =================================
/// 修改者    ：
/// 修改日期    ：
/// 修改内容    ：
/// =================================
///
/// ***********************************************************************

using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sfan.Core.DataResult;
using Sfan.Core.Domain;
using Sfan.Infrastructure.Repositories;
using Sfan.Web.Application.Command.Customer;
using Sfan.Web.Application.Command.Customer.Dto;
using Sfan.Web.Application.Commands.Customer.Dto;
using Sfan.Web.Infrastructure.Extensions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sfan.Web.Application.CommandHandler
{
    public class CustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Unit>, IRequestHandler<UpdateCustomerCommand, Unit>, IRequestHandler<DeleteCustomerCommand, Unit>, IRequestHandler<PageCustomerCommand, PagedResultDto<CustomersDto>>, IRequestHandler<DetailCuustomerCommand, CustomerDto>
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
        /// 获取所有
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<CustomersDto>> Handle(PageCustomerCommand request, CancellationToken cancellationToken)
        {

            CustomersDto customersDto = new CustomersDto();
            customersDto = null;
            var ss = customersDto.Name;
            var query = _customerRepository.TableNoTracking;
            var data = await query.PageBy(request.PageIndex, request.PageSize).ToListAsync();
            var result = _mapper.Map<List<CustomersDto>>(data);
            return new PagedResultDto<CustomersDto>(await query.CountAsync(), result);
        }
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CustomerDto> Handle(DetailCuustomerCommand request, CancellationToken cancellationToken)
        {
            var data = await _customerRepository.GetByIdAsync(request.Id);
            var result = _mapper.Map<CustomerDto>(data);
            return result;
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
