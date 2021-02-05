using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Events
{
    /// <summary>
    /// 功能描述    ：CreateProductEvent  
    /// 创 建 者    ：鲁岩奇
    /// 创建日期    ：2021/2/5 9:52:13 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/2/5 9:52:13 
    /// </summary>
   public class CreateProductEvent: IDomainEvent
    {
        public Product.Product Product { get; private set; }
        public CreateProductEvent(Product.Product product)
        {
            this.Product = product;
        }
    }
}
