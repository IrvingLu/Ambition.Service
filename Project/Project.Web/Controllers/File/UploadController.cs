using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Core;
using Project.Core.Extensions;
using Project.Web.Application.File;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Project.Web.Controllers.File
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class UploadController : BaseController
    {
        private readonly IOssService _ossService;
        public UploadController(IOssService ossService)
        {
            _ossService = ossService;
        }
        /// <summary>
        /// oss文件上传
        /// </summary>
        /// <returns></returns>
        [HttpPost("oss")]
        public async Task<IActionResult> UploadFile([FromForm] IFormCollection formData, UploadType type)
        {
            var userid = User.GetUserId().Replace("-", "");
            var time = DateTime.Now.ToString("yyyyMMddHHmm");
            var files = formData.Files;
            var filePathList = new List<string>();
            foreach (var item in files)
            {
                string relativeAddress = "";
                if (!string.IsNullOrEmpty(item.ContentType))
                {
                    //文件类型
                    var fileExtension = Path.GetExtension(item.FileName).ToLower();//获取文件的后缀  //判断文件类型是否是允许的类型
                    byte[] data;
                    using (var stream = item.OpenReadStream())
                    {
                        data = new byte[stream.Length];
                        stream.Read(data, 0, (int)stream.Length);
                    }
                    relativeAddress = await _ossService.UploadAsync(data, userid + "-" + time + fileExtension, type);
                    filePathList.Add(relativeAddress);
                }
                else
                {
                    return Ok(new BaseResult((int)HttpStatusCode.InternalServerError, "上传图片失败"));
                }
            }
            return Ok(new DataResult((int)HttpStatusCode.OK, "Success", filePathList));
        }
    }
}
