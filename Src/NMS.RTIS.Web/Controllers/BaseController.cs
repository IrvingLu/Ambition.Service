using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using NMS.RTIS.Core.ApiResult;

namespace NMS.RTIS.Web.Controllers
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
        /// <returns></returns>
        [NonAction]
        public IActionResult Success()
        {
            return Ok(new BaseResult(StatusCodes.Status200OK, "Success"));
        }
        /// <summary>
        /// 成功返回数据
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public IActionResult Success([ActionResultObjectValue] object data, int? count = null)
        {
            return count != null
                ? Ok(new DataListResult(StatusCodes.Status200OK, "Success", data, (int)count))
                : Ok(new DataResult(StatusCodes.Status200OK, "Success", data));

        }
        /// <summary>
        /// 内部逻辑可识别错误，返回统一状态码，前端拦截
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public IActionResult Error([ActionResultObjectValue] string msg)
        {
            return Ok(new BaseResult(800, msg));
        }

    }
}
