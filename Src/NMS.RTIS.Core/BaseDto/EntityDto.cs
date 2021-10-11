using System;

namespace NMS.RTIS.Core.BaseDto
{
    /// <summary>
    /// 功能描述    ：主键实体
    /// 创 建 者    ：Seven
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/2/4 9:40:56 
    /// </summary>
    public class EntityDto
    {
        public Guid Id { get; set; }

        public byte[] RowVersion { get; set; }
    }
}
