using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NMS.RTIS.Core.Abstractions
{
    /// <summary>
    /// 功能描述    ：基础实体
    /// 创 建 者    ：鲁岩奇
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/1/12 9:40:56 
    /// </summary>
    public abstract class Entity
    {
        [Comment("主键")]
        public Guid Id { get; set; }

        [Comment("是否被删除")]
        public bool IsDelete { get; set; }

        [Comment("创建用户")]
        public string CreateUserName { get; set; }

        [Comment("创建时间")]
        public DateTime CreateTime { get; set; }

        [Comment("更新用户")]
        public string UpdateUserName { get; set; }

        [Comment("更新时间")]
        public DateTime? UpdateTime { get; set; }

        [Comment("数据行版本号")]
        [ConcurrencyCheck]
        public byte[] RowVersion { get; set; }

        //表示对象是否为全新创建的，未持久化的
        public bool IsTransient()
        {
            return EqualityComparer<Guid>.Default.Equals(Id, default);
        }


        #region DomainEvent 
        private List<IDomainEvent> _domainEvents;
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents?.AsReadOnly();

        public void AddDomainEvent(IDomainEvent eventItem)
        {
            _domainEvents ??= new List<IDomainEvent>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(IDomainEvent eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
        #endregion
    }
}
