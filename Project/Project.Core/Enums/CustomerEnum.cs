using System.ComponentModel;

namespace Project.Core.Enums
{
    public enum CustomerEnum
    {
    }
    /// <summary>
    /// 位移枚举
    /// </summary>
    public enum PublishChannel
    {
        [Description("店铺首页")]
        storeHome = 1,//1
        [Description("商品详情页")]
        product = 1 << 1,//2
        [Description("领券中心")]
        couponCenter = 1 << 2//4
    }
}
