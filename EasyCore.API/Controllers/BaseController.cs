/*-------------------------------------------------------------------------
 * 作者：WuTian
 * 版本号：v1.0
 * 本类主要用途描述及食用方式：
 * 基类控制器
 *  -------------------------------------------------------------------------*/
using Microsoft.AspNetCore.Mvc;

namespace EasyCore.API.Controllers
{

    /// <summary>
    /// 基类控制器
    /// </summary>
    public class BaseController : ControllerBase
    {
        public ContentResult JsonResult(dynamic data = null)
        {
            ContentResult result = JsonContentResultBuilder.BuildViewJsonResult(data);

            return result;
        }
    }
}
