

using System;
using System.Collections.Generic;

namespace Project.Core.Entities
{
    public abstract class Entity 
    {
        public Guid Id { get; set; }

        //表示对象是否为全新创建的，未持久化的
        public bool IsTransient()
        {
            return EqualityComparer<Guid>.Default.Equals(Id, default);
        }
    }

    public class PageEntity {


        /// <summary>
        /// 第几个页面
        /// </summary>
       public int PageIndex { get; set; }

        /// <summary>
        /// 页面显示多少
        /// </summary>
       public int PageSize { get; set; }
    }
}
