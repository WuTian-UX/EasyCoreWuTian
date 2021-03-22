using EasyCore.BLL;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace EasyCore.API
{
    public class JsonWebTokenValidateAttribute : ActionFilterAttribute
    {



        #region 服务依赖

        private readonly ITokenService tokenService;
        public JsonWebTokenValidateAttribute(ITokenService _tokenService)
        {
            tokenService = _tokenService;
        }
        #endregion




        public override void OnActionExecuting(ActionExecutingContext context)
        {

            //如果有忽略JsonWebToken校验的特性 则不进行校验
            if (context.ActionDescriptor.EndpointMetadata.Any(item => item is JsonWebTokenValidateIgnoreAttribute))
            {
                return;
            }


            string authHeader = context.HttpContext.Request.Headers["Authorization"];//Header中的token


            if (authHeader == null || authHeader.IndexOf("Bearer ") < -1)
            {
                throw new Exception("没获取到正确的JsonWebToken");
            }

            authHeader = authHeader.Replace("Bearer ", "");

            tokenService.Validate(authHeader);


        }

    }
}

