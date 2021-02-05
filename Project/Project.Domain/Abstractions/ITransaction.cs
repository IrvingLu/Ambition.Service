using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Abstractions
{
    /// <summary>
    /// 功能描述    ：ITransaction  
    /// 创 建 者    ：鲁岩奇
    /// 创建日期    ：2021/2/5 15:01:50 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/2/5 15:01:50 
    /// </summary>
    public interface ITransaction
    {
        IDbContextTransaction GetCurrentTransaction();

        bool HasActiveTransaction { get; }

        Task<IDbContextTransaction> BeginTransactionAsync();

        Task CommitTransactionAsync(IDbContextTransaction transaction);

        void RollbackTransaction();
    }
}
