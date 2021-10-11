/**********************************************************************
* 命名空间：NMS.RTIS.Service.Patient.Command
*
* 功  能：更新患者信息
* 类  名：UpdatePatientCommand
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

using MediatR;
using NMS.RTIS.Core.BaseDto;

namespace NMS.RTIS.Service.Patient.Command
{
    public class UpdatePatientCommand : EntityDto, IRequest
    {
        public string Name { get; set; }
    }
}
