/**********************************************************************
* 命名空间：NMS.RTIS.Core.Abstractions
*
* 功  能：基础实体类
* 类  名：Entity
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NMS.RTIS.Core.Abstractions
{
    public abstract class Entity
    {
        #region Base

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

        #endregion

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
