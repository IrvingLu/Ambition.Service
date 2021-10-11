/**********************************************************************
* 命名空间：NMS.RTIS.Core.Abstractions
*
* 功  能：领域事件
* 类  名：IDomainEventHandler
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

using MediatR;

namespace NMS.RTIS.Core.Abstractions
{
    public interface IDomainEventHandler<T> : INotificationHandler<T> where T : IDomainEvent
    {
      
    }
}
