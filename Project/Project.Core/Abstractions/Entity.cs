

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
}
