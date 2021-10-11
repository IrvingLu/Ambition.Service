/**********************************************************************
* 命名空间：NMS.RTIS.Service.Patient.Command
*
* 功  能：获取患者详情
* 类  名：PatientDetailCommand
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/


using MediatR;
using NMS.RTIS.Core.BaseDto;
using NMS.RTIS.Service.Patient.Dto;
using System;

namespace NMS.RTIS.Service.Patient.Command
{
    public class PatientDetailCommand : EntityDto, IRequest<PatientDetailDto>
    {
        public PatientDetailCommand(Guid id)
        {
            this.Id = id;
        }
    }
}
