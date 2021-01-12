using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.Domain;
using System.Collections.Generic;

namespace Project.Core.Domain.Identity
{
    /// <summary>
    /// 功能描述    ：用户表
    /// 创 建 者    ：鲁岩奇
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/1/12 9:40:56 
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// 用户地址
        /// </summary>
        public Address Address { get; set; }
    }

    [Owned]
    public class Address:ValueObject
    {
        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; private set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; private set; }

        /// <summary>
        /// 区县
        /// </summary>
        public string County { get; private set; }

        /// <summary>
        /// 街道
        /// </summary>
        public string Street { get; private set; }


        public Address() { }
        public Address(string province, string city, string county, string street)
        {
            this.Province = province;
            this.City = city;
            this.County = county;
            this.Street = street;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new System.NotImplementedException();
        }
    }
}
