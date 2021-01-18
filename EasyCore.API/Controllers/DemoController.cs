/*-------------------------------------------------------------------------
 * 作者：WuTian
 * 版本号：v1.0
 * 本类主要用途描述及食用方式：
 * 所有接口使用JsonResult(data=null)返回数据
 *  -------------------------------------------------------------------------*/
using EasyCore.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using EasyCore.Unity;
using EasyCore.BLL;

namespace EasyCore.API.Controllers
{

    public class DemoController : BaseController
    {

        public ActionResult Login(DemoParaModel paraModel)
        {


            //扩展的Where方法有四个参数重载。
            //传进去Func<T,true>那么返回值是IEnumable的接口类型的集合
            //传进去Expression<Func<T,true>>那么返回的是IQueryable类型的接口集合
            //Expression<Func<DemoParaModel, bool>> lambda = t => true;

            Expression<Func<View_DemoPerson, bool>> lambdaExpression = t => true;

            if (!string.IsNullOrWhiteSpace(paraModel.Age))
            {
                lambdaExpression = lambdaExpression.And(t => t.Age == paraModel.Age);
            }

            List<View_DemoPerson> list = new DemoService().DemoDoSomeThing(lambdaExpression);


            return JsonResult(list);





        }













    }
}
