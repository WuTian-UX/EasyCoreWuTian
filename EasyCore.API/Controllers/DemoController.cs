/*-------------------------------------------------------------------------
 * 作者：WuTian
 * 版本号：v1.0
 * 本类主要用途描述及食用方式：
 * 所有接口使用JsonResult(data=null)返回数据
 *  -------------------------------------------------------------------------*/
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EasyCore.API.Controllers
{

    public class DemoController : BaseController
    {

        public ActionResult Login(DemoParaModel paraModel)
        {

            List<int> ss = new List<int>() { 1, 2, 3, 4, 5 };

            return JsonResult(ss);
        }
    }
}
