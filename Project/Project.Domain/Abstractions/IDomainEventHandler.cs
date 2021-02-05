using MediatR;

namespace Project.Domain
{
    /// <summary>
    /// 功能描述    ：IDomainEventHandler  
    /// 创 建 者    ：鲁岩奇
    /// 创建日期    ：2021/2/5 9:41:43 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/2/5 9:41:43 
    /// </summary>
    public interface IDomainEventHandler<T> : INotificationHandler<T> where T : IDomainEvent
    {
      
    }
}
