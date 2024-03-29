﻿/**********************************************************************
* 命名空间：NMS.RTIS.Web.Controllers
*
* 功  能：基础Controller，封装返回对象
* 类  名：BaseController
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using NMS.RTIS.Core.ApiResult;

namespace NMS.RTIS.Web.Controllers
{
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
