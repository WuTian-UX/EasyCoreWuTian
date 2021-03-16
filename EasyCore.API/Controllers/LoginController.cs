using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyCore.BLL;
using EasyCore.Entity;
using EasyCore.Unity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyCore.API.Controllers
{



    public class LoginController : BaseController
    {

        #region 服务

        private readonly ITokenHelper tokenHelper;
        public LoginController(ITokenHelper _tokenHelper)
        {
            tokenHelper = _tokenHelper;
        }

        #endregion




        public ActionResult Login(LoginParaModel paraModel)
        {

            //根据用户名和密码去数据库查询，判断用户是否存在
            if (false)
            {
                throw new Exception("当前用户不存在");
            }


            //给jwt提供携带的数据
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

            keyValuePairs.Add("UserLoginName", paraModel.UserLoginName);
            TnToken tnToken = tokenHelper.CreateToken(keyValuePairs);



            //返回数据
            return JsonResult(tnToken);



        }
    }
}
