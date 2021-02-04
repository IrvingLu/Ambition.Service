using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Project.Core;

namespace Project.Web.Controllers
{
    /// <summary>
    /// 功能描述    ：自定义Controller
    /// 创 建 者    ：Seven
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/1/12 9:40:56 
    /// </summary>
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ObjectResult Success()
        {
            return Ok(new BaseResult(StatusCodes.Status200OK, "Success"));
        }
        /// <summary>
        /// 成功返回数据
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ObjectResult Success([ActionResultObjectValue] object data, int? count = null)
        {
            return count != null
                ? Ok(new DataListResult(StatusCodes.Status200OK, "Success", data, (int)count))
                : Ok(new DataResult(StatusCodes.Status200OK, "Success", data));

        }
        /// <summary>
        /// 内部逻辑可识别错误，返回统一状态码，前端拦截
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ObjectResult Error([ActionResultObjectValue] string msg, object data)
        {
            return Ok(new DataResult(500, msg, data));
        }



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
