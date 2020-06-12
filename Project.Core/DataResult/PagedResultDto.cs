/// ***********************************************************************
///
/// =================================
/// CLR版本    ：4.0.30319.42000
/// 命名空间    ：Project.Core.DataResult
/// 文件名称    ：PagedResultDto.cs
/// =================================
/// 创 建 者    ：鲁岩奇
/// 创建日期    ：2020/4/13 15:42:41 
/// 功能描述    ：
/// 使用说明    ：
/// =================================
/// 修改者    ：
/// 修改日期    ：
/// 修改内容    ：
/// =================================
///
/// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Core.DataResult
{
    [Serializable]
    public class PagedResultDto<T>: ListResultDto<T>
    {
        /// <summary>
        /// 总数
        /// </summary>
        public int TotalCount { get; set; }

        public PagedResultDto()
        {

        }

        public PagedResultDto(int totalCount, IReadOnlyList<T> items) : base(items)
        {
            TotalCount = totalCount;
        }
    }
}
