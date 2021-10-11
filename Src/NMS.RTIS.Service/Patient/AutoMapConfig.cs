/**********************************************************************
* 命名空间：NMS.RTIS.Service.Patient
*
* 功  能：映射
* 类  名：AutoMapConfig
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

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
