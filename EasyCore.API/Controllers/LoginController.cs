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

        private readonly ITokenService tokenHelper;
        public LoginController(ITokenService _tokenHelper)
        {
            tokenHelper = _tokenHelper;
        }

        #endregion

        public ActionResult Login(LoginParaModel paraModel)
        {


            //根据用户名和密码去数据库查询，判断用户是否存在，判断密码是否正确
            if (paraModel.UserLoginName == "NoUser")
            {
                throw new Exception("当前用户不存在");
            }

            //带额外数据的JWT 
            //TnToken tnToken = tokenHelper.CreateToken(keyValuePairs);

            //不带额外数据的JWT 
            LoginViewModel viewModel = tokenHelper.CreateToken();

            //返回前端
            return JsonResult(viewModel);

        }
    }


}
