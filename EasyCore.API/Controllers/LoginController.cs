using EasyCore.BLL;
using EasyCore.Model;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EasyCore.API.Controllers
{
    [JsonWebTokenValidateIgnore]
    public class LoginController : BaseController
    {

        #region 服务依赖

        private readonly ITokenService tokenService;
        public LoginController(ITokenService _tokenService)
        {
            tokenService = _tokenService;
        }

        #endregion

        public ActionResult Login(LoginParaModel paraModel)
        {


            //根据用户名和密码去数据库查询，判断用户是否存在，判断密码是否正确。并获取用户ID
            if (paraModel.UserLoginName == "NoUser")
            {
                throw new Exception("当前用户不存在");
            }
            

            //负载数据
            JwtClaimModel claimModel = new JwtClaimModel
            {
                UserId = "10001"
            };

            //负载数据的JWT 
            LoginViewModel viewModel = tokenService.CreateToken(claimModel);


            //返回前端
            return JsonResult(viewModel);

        }
    }


}
