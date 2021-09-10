using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NMS.RTIS.Infrastructure.EntityTypeConfiguration
{
    /// <summary>
    /// 功能描述    ：数据库映射配置
    /// 创 建 者    ：Seven
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/1/12 9:40:56 
    /// </summary>
    public class PatientEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Patient.Patient>
    {
        public void Configure(EntityTypeBuilder<Domain.Patient.Patient> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}
