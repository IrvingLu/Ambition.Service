/**********************************************************************
* 命名空间：NMS.RTIS.Infrastructure.Core
*
* 功  能：工作单元接口
* 类  名：IUnitOfWork
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

using System;
using System.Threading;
using System.Threading.Tasks;

namespace NMS.RTIS.Infrastructure.Core
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }
}
