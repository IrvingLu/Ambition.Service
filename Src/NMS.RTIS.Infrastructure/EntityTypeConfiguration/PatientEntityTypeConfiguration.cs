/**********************************************************************
* 命名空间：NMS.RTIS.Infrastructure.EntityTypeConfiguration
*
* 功  能：数据库映射配置
* 类  名：PatientEntityTypeConfiguration
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NMS.RTIS.Infrastructure.EntityTypeConfiguration
{
    public class PatientEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Patient.Patient>
    {
        public void Configure(EntityTypeBuilder<Domain.Patient.Patient> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}
