/**********************************************************************
* 命名空间：NMS.RTIS.Service.Patient.Command
*
* 功  能：删除患者
* 类  名：DeletePatientCommand
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

using MediatR;
using NMS.RTIS.Core.BaseDto;
using System;

namespace NMS.RTIS.Service.Patient.Command
{
    public class DeletePatientCommand:EntityDto,IRequest
    {
        public DeletePatientCommand(Guid id)
        {
            this.Id = id;
        }
    }
}
