/************************************************************************
*本页作者    ：鲁岩奇
*创建日期    ：2020/11/10 9:51:36 
*功能描述    ：查询
*使用说明    ：查询
***********************************************************************/

using AutoMapper;
using MediatR;
using NMS.RTIS.Core.BaseDto;
using NMS.RTIS.Infrastructure.Dapper;
using NMS.RTIS.Infrastructure.Repositories;
using NMS.RTIS.Web.Application.Patient.Command;
using NMS.RTIS.Web.Application.Patient.Dto;
using NMS.RTIS.Web.Core.Extensions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NMS.RTIS.Web.Application.Patient.Query
{
    public class PatientQueryHandler : IRequestHandler<PatientsCommand, PagedResultDto>, IRequestHandler<PatientDetailCommand, PatientDetailDto>
    {
        private readonly IRepository<Domain.Patient.Patient> _patientRepository;
        private readonly IDapperQuery _dapper;
        private readonly IMapper _mapper;

        public PatientQueryHandler(IRepository<Domain.Patient.Patient> patientRepository, IDapperQuery dapper, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _dapper = dapper;
            _mapper = mapper;
        }

        /// <summary>
        /// 获取患者列表
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<PagedResultDto> Handle(PatientsCommand request, CancellationToken cancellationToken)
        {
            var query = _patientRepository.TableNoTracking;
            //if (true)
            //{
            //    throw new InternalException("ceshi");
            //}
            var pageResult = await query.ToPageListAsync(request.PageIndex, request.PageSize);
            pageResult.Data = _mapper.Map<List<PatientListViewDto>>(pageResult.Data);
            return pageResult;
        }
        /// <summary>
        /// 获取患者详情
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<PatientDetailDto> Handle(PatientDetailCommand request, CancellationToken cancellationToken)
        {
            //const string Sql = "SELECT * FROM dbo.\"Patient\" WHERE Id=@Id";
            //var data = await _dapper.QueryFirstAsync<Domain.Patient.Patient>(Sql, new { request.Id });
            var data = await _patientRepository.FindByIdAsync(request.Id);
            var result = _mapper.Map<PatientDetailDto>(data);
            return result;
        }
    }
}
