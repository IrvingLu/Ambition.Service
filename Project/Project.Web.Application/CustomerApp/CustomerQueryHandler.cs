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
using Project.Infrastructure.Repositories;
using Project.Web.Application.CustomerApp.Commands;
using Project.Web.Application.CustomerApp.Dto;
using Project.Web.Core.Extensions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Web.Appliccation.CustomerApp
{
    public class CustomerQueryHandler : IRequestHandler<PageCustomerCommand, PagedResultDto>, IRequestHandler<DetailCuustomerCommand, CustomerDto>
    {
        #region Fileds
        private readonly IRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public CustomerQueryHandler(IRepository<Customer> customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
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
        public async Task<PagedResultDto> Handle(PageCustomerCommand request, CancellationToken cancellationToken)
        {
            var query = _customerRepository.TableNoTracking;
            var pageResult = await query.ToPageListAsync(request.PageIndex, request.PageSize);
            pageResult.Data = _mapper.Map<List<CustomersDto>>(pageResult.Data);
            return pageResult;
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
        #endregion

    }

}
