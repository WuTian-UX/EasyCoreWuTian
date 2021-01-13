/*-------------------------------------------------------------------------
 * 作者：WuTian
 * 版本号：v1.0
 * 本类主要用途及食用方式：
 * 捕捉控制器所有错误，格式化为ContentResult后返回前端
 *  -------------------------------------------------------------------------*/
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EasyCore.API.Controllers
{
    /// <summary>
    /// 错误捕捉过滤器 NetCore版
    /// </summary>
    public class ErrorCatchAttribute : ExceptionFilterAttribute
    {
        
        public override void OnException(ExceptionContext actionExecutedContext)
        {

            ContentResult result = JsonContentResultBuilder.BuildViewJsonResult(null, StatuCode.Fail, actionExecutedContext.Exception.Message);
            actionExecutedContext.Result = result;

        }


    }
}
