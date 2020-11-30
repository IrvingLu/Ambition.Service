

using System;
using System.Collections.Generic;

namespace Project.Domain
{
    public abstract class Entity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 是否被删除
        /// </summary>
        public bool IsDelete { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }

        //表示对象是否为全新创建的，未持久化的
        public bool IsTransient()
        {
            return EqualityComparer<Guid>.Default.Equals(Id, default);
        }
    }
}
