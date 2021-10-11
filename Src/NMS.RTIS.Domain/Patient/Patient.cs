/**********************************************************************
* 命名空间：NMS.RTIS.Domain.Patient
*
* 功  能：患者基本信息
* 类  名：Patient
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

using Microsoft.EntityFrameworkCore;
using NMS.RTIS.Core.Abstractions;
using NMS.RTIS.Domain.Patient.Events;

namespace NMS.RTIS.Domain.Patient
{

    public class Patient : Entity, IAggregateRoot
    {
        [Comment("患者姓名")]
        public string Name { get; set; }

        [Comment("联系方式")]
        public string Phone { get; set; }

        [Comment("性别")]
        public int Sex { get; set; }


        public Patient(string name, string phone = null)
        {
            Name = name;
            Phone = phone;
            AddDomainEvent(new CreatePatientEvent(this));//举例
        }
    }
}
