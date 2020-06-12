/// ***********************************************************************
///
/// =================================
/// CLR版本    ：4.0.30319.42000
/// 命名空间    ：Project.Core
/// 文件名称    ：Entity.cs
/// =================================
/// 创 建 者    ：鲁岩奇
/// 创建日期    ：2020/4/13 11:12:31 
/// 功能描述    ：
/// 使用说明    ：
/// =================================
/// 修改者    ：
/// 修改日期    ：
/// 修改内容    ：
/// =================================
///
/// ***********************************************************************

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Core.Entities
{
    public abstract class Entity : IEntity
    {

        public Guid Id { get; set; }

        //表示对象是否为全新创建的，未持久化的
        public bool IsTransient()
        {
            return EqualityComparer<Guid>.Default.Equals(Id, default);
        }

        /// <summary>
        /// 修改人员
        /// </summary>
        public string ModifyUser { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModifyTime { get; set; }
        /// <summary>
        /// 修改次数
        /// </summary>
        public int ModifyCount { get; set; }

        private List<INotification> _domainEvents;
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents = _domainEvents ?? new List<INotification>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents?.Remove(eventItem);
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
