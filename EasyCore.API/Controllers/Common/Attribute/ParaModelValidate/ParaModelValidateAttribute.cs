/*-------------------------------------------------------------------------
 * 作者：WuTian
 * 版本号：v3.0
 * 本类主要用途及食用方式：
 * 1.0版：继承ActionFilterAttribute，使用此特性校验参数。
 * 2.0版：添加参数描述符。修复未传参时反射无法绑定参数模型,以及部分方法无须参数导致绑定出错的问题。
 * 3.0版：参数校验特性在StartUp中全局注册，不校验的方法自行添加[ParaModelValidateIgnore]特性
 *  -------------------------------------------------------------------------*/
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;

namespace EasyCore.API
{

    /// <summary>
    /// 参数模型检验过滤器 NetCore版
    /// </summary>
    public class ParaModelValidateAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {

            //如果有忽略参数校验的特性 则不进行校验
            if (context.ActionDescriptor.EndpointMetadata.Any(item => item is ParaModelValidateIgnoreAttribute))
            {
                return;
            }

            //本方法的所有参数描述符
            IList<ParameterDescriptor> actionParameters = context.ActionDescriptor.Parameters;

            //只有这个方法需要参数的时候才进行校验
            if (actionParameters.Count != 0)
            {

                dynamic paraModel = context.ActionArguments.FirstOrDefault().Value;

                ParaModelValidateHelper.Validate(paraModel);

            }

        }

    }




}
