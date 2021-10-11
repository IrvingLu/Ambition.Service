/**********************************************************************
* 命名空间：NMS.RTIS.Domain.Identity
*
* 功  能：用户类
* 类  名：ApplicationUser
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NMS.RTIS.Core.Abstractions;
using System.Collections.Generic;

namespace NMS.RTIS.Domain.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [Comment("昵称")]
        public string NickName { get; set; }

        [Comment("头像")]
        public string Avatar { get; set; }

        [Comment("地址")]
        public Address Address { get; set; }
    }

    [Owned]
    public class Address:ValueObject
    {
        [Comment("省份")]
        public string Province { get; private set; }

        [Comment("城市")]
        public string City { get; private set; }

        [Comment("区县")]
        public string County { get; private set; }

        [Comment("街道")]
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
