/**********************************************************************
* 命名空间：NMS.RTIS.Service.Patient.Dto
*
* 功  能：患者详情
* 类  名：PatientDetailDto
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

using NMS.RTIS.Core.BaseDto;

namespace NMS.RTIS.Service.Patient.Dto
{
    public class PatientDetailDto : EntityDto
    {
        public string Name { get; set; }
    }
}
