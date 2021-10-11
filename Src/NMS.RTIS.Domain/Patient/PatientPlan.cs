/**********************************************************************
* 命名空间：NMS.RTIS.Domain.Patient
*
* 功  能：患者计划信息
* 类  名：PatientPlan
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

using Microsoft.EntityFrameworkCore;
using NMS.RTIS.Core.Abstractions;

namespace NMS.RTIS.Domain.Patient
{
    public class PatientPlan:Entity
    {
        [Comment("计划名称")]
        public string PlanName { get; set; }
    }
}
