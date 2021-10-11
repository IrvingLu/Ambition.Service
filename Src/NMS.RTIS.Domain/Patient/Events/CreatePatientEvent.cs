/**********************************************************************
* 命名空间：NMS.RTIS.Domain.Patient.Events
*
* 功  能：创建患者领域事件
* 类  名：CreatePatientEvent
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

using NMS.RTIS.Core.Abstractions;

namespace NMS.RTIS.Domain.Patient.Events
{

    public class CreatePatientEvent : IDomainEvent
    {
        public Patient Patient { get; private set; }
        public CreatePatientEvent(Patient patient)
        {
            this.Patient = patient;
        }
    }
}
