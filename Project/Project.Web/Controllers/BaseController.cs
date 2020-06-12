using Microsoft.AspNetCore.Mvc;

namespace Project.Web.Controllers
{
    /// <summary>
    /// 自定义状态码
    /// </summary>
    public class BaseController : ControllerBase
    {
        #region 用户相关
        /// <summary>
        /// 用户名密码错误或者用户锁定
        /// </summary>
        /// <returns></returns>
        protected int InvokeHttp702()
        {
            Response.StatusCode = 702;
            return new StatusCodeResult(702).StatusCode;
        }
        #endregion

    }
}
