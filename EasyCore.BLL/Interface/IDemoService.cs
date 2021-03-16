/*-------------------------------------------------------------------------
 * 作者：WuTian
 * 版本号：v1.0
 * 本类主要用途描述及食用方式：
 * 业务层服务接口
 *  -------------------------------------------------------------------------*/

using EasyCore.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EasyCore.BLL
{
    public interface IDemoService
    {

        List<DemoViewPerson> DemoDoSomeThing(Expression<Func<DemoViewPerson, bool>> lambda = null);

    }
}
