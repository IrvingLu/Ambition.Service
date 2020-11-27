using Project.Core.Abstractions;
using Project.Core.Entities;

namespace Project.Domain.Product
{
    public class Product: Entity,IAggregateRoot
    {
        /// <summary>
        /// 产品名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 产品图片地址
        /// </summary>
        public string PicPath { get; set; }
    }
}
