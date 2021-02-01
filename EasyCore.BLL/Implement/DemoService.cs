/*-------------------------------------------------------------------------
 * 作者：WuTian
 * 版本号：v1.0
 * 本类主要用途描述及食用方式：
 * 业务层服务实例,继承服务基类和本服务的接口
 * DbContext在ServiceBase中构造
 *  -------------------------------------------------------------------------*/
using EasyCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Chloe;

namespace EasyCore.BLL
{
    public class DemoService : ServiceBase, IDemoService
    {

        public List<ViewDemoPerson> DemoDoSomeThing(Expression<Func<ViewDemoPerson, bool>> lambda = null)
        {
           
            IQuery<DemoName> query_DemoName = DbContext.Query<DemoName>();
            IQuery<DemoAge> query_DemoAge = DbContext.Query<DemoAge>();

            IQuery<ViewDemoPerson> query_View_DemoPerson =
                query_DemoName.LeftJoin(query_DemoAge, (x, y) => x.ID == y.ID)
                .Select(
                    (x, y) => new ViewDemoPerson
                    {
                        ID = x.ID,
                        Name = x.Name,
                        Age = y.Age
                    });


            query_View_DemoPerson = query_View_DemoPerson.Where(lambda);

            List<ViewDemoPerson> list = query_View_DemoPerson.ToList();

            return list;

        }

    }
}
