/*-------------------------------------------------------------------------
 * 作者：WuTian
 * 版本号：v1.0
 * 本类主要用途及食用方式：
 * 鉴权过滤器（未完成）
 *  -------------------------------------------------------------------------*/
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace EasyCore.API
{
    public class CustomAuthorizationFilterAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {

            //如果方法上面标记了AllowAnonymous特性，则跳过登录校验-以及权限检查
            if (context.ActionDescriptor.EndpointMetadata.Any(item => item is AllowAnonymousAttribute))
            {
                return;
            }

            //获取Cookie
            string userCookie = context.HttpContext.Request.Cookies["CurrentUser"];

            if (userCookie == null)
            {
                //没有Cookie则跳转到登陆页面
                context.Result = new RedirectResult("/Home/Login");
            }
            else
            {
                return;
            }


        }
    }
}
