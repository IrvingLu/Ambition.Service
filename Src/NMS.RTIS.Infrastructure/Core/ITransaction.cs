/**********************************************************************
* 命名空间：NMS.RTIS.Infrastructure.Core
*
* 功  能：事务接口
* 类  名：ITransaction
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace NMS.RTIS.Infrastructure.Core
{
    public interface ITransaction
    {
        IDbContextTransaction GetCurrentTransaction();

        bool HasActiveTransaction { get; }

        Task<IDbContextTransaction> BeginTransactionAsync();

        Task CommitTransactionAsync(IDbContextTransaction transaction);

        void RollbackTransaction();
    }
}
