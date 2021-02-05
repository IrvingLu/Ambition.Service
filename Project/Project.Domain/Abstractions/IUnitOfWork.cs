using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Project.Domain.Abstractions
{
    /// <summary>
    /// 功能描述    ：IUnitOfWork  
    /// 创 建 者    ：鲁岩奇
    /// 创建日期    ：2021/2/5 13:44:58 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/2/5 13:44:58 
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        void Begin();

        Task CommitAsync();
    }
}
