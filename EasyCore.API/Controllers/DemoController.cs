/*-------------------------------------------------------------------------
 * 作者：WuTian
 * 版本号：v1.0
 * 本类主要用途描述及食用方式：
 * 所有接口使用JsonResult(data=null)返回数据
 * 传进去Expression<Func<T,true>>那么返回的是IQueryable类型的接口集合
 * 传进去Func<T,true>那么返回值是IEnumable的接口类型的集合
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

        #region 服务

        private readonly IDemoService demoService;
        public DemoController(IDemoService _demoService)
        {
            demoService = _demoService;
        }

        #endregion

        [ParaModelValidateIgnore]
        public ActionResult Login(DemoParaModel paraModel)
        {

            //创建表达式
            Expression<Func<ViewDemoPerson, bool>> lambdaExpression = t => true;

            //构造表达式
            if (!string.IsNullOrWhiteSpace(paraModel.Age))
            {
                lambdaExpression = lambdaExpression.And(t => t.Age == paraModel.Age);
            }
            if (!string.IsNullOrWhiteSpace(paraModel.Name))
            {
                lambdaExpression = lambdaExpression.And(t => t.Name == paraModel.Name);
            }


            //获取返回模型数据
            List<ViewDemoPerson> list = demoService.DemoDoSomeThing(lambdaExpression);

            //返回数据
            return JsonResult(list);

        }

    }
}
