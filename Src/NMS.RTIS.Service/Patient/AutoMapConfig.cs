/************************************************************************
*本页作者    ：鲁岩奇
*创建日期    ：2020/11/10 9:51:36 
*功能描述    ：自动映射
*使用说明    ：自动映射
***********************************************************************/

using AutoMapper;
using NMS.RTIS.Service.Patient.Command;
using NMS.RTIS.Service.Patient.Dto;

namespace NMS.RTIS.Service.Patient
{
    public class AutoMapConfig : Profile
    {
        public AutoMapConfig()
        {
            CreateMap<Domain.Patient.Patient, PatientDetailDto>();
            CreateMap<Domain.Patient.Patient, PatientListViewDto>();


            CreateMap<UpdatePatientCommand, Domain.Patient.Patient>();
        }
    }
}
