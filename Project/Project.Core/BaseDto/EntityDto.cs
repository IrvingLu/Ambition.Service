/************************************************************************
*本页作者    ：鲁帅
*创建日期    ：2020/11/10 9:51:36 
*功能描述    ：
*使用说明    ：
***********************************************************************/

using System;

namespace Project.Infrastructure.Core.BaseDto
{
    public  class EntityDto<TKey>
    {
        public TKey Id { get; set; }
    }
}
