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
using System.Linq;

namespace EasyCore.BLL
{
    public class DemoService : ServiceBase, IDemoService
    {

        public List<ViewDemoPerson> DemoDoSomeThing(Expression<Func<ViewDemoPerson, bool>> lambda = null)
        {

            IQuery<DemoName> demoNameQ = DbContext.Query<DemoName>();
            IQuery<DemoAge> demoAgeQ = DbContext.Query<DemoAge>();

            IQuery<ViewDemoPerson> demoPersonQ =
                demoNameQ.LeftJoin(demoAgeQ, (x, y) => x.ID == y.ID)
                .Select(
                    (x, y) => new ViewDemoPerson
                    {
                        ID = x.ID,
                        Name = x.Name,
                        Age = y.Age
                    });

            demoPersonQ = demoPersonQ.Where(lambda);



            List<ViewDemoPerson> demoPersonList = demoPersonQ.ToList();

            return demoPersonList;

        }

    }

}
