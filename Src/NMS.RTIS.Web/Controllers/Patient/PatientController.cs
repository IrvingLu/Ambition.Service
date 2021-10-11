/**********************************************************************
* 命名空间：NMS.RTIS.Web.Controllers
*
* 功  能：患者api
* 类  名：PatientController
* 日  期：2021/10/11 14:44:32
* 负责人：lu-shuai
*
* 版权所有：公司
*
**********************************************************************/

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NMS.RTIS.Core.BaseDto;
using NMS.RTIS.Service.Patient.Command;
using System.Threading.Tasks;

namespace NMS.RTIS.Web.Controllers.Patient
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Authorize]
    public class PatientController : BaseController
    {
        #region Fields
        private readonly IMediator _mediator;
        #endregion

        #region Ctor
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="mediator"></param>
        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Query

        /// <summary>
        /// 获取患者列表
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("patients")]
  
        public async Task<IActionResult> GetPatients([FromQuery] PatientsCommand command)
        {
            //var userId = User.GetUserId();
            var result = await _mediator.Send(command);
            //result = null;
            //var ss = result.Data;
            return Success(result.Data, result.TotalCount);
        }
        /// <summary>
        /// 获取患者详情
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet("patient")]
        public async Task<IActionResult> GetPatientDetail([FromQuery] EntityDto dto)
        {
            var result = await _mediator.Send(new PatientDetailCommand(dto.Id));
            return Success(result);
        }
        #endregion

        #region Command
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("insert")]
        public async Task<IActionResult> InsertAsync(CreatePatientCommand command)
        {
            await _mediator.Send(command);
            return Success();
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync(UpdatePatientCommand command)
        {
            await _mediator.Send(command);
            return Success();
        }
        /// <summary>
        /// 删除单条
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteAsync(DeletePatientCommand command)
        {
            await _mediator.Send(command);
            return Success();
        }
        #endregion
    }
}
