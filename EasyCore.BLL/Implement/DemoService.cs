/*-------------------------------------------------------------------------
 * 作者：WuTian
 * 版本号：v1.0
 * 本类主要用途描述及食用方式：
 * 业务层服务实例,继承服务基类和本服务的接口
 * DbContext在ServiceBase中构造
 *  -------------------------------------------------------------------------*/
using Chloe;
using EasyCore.Entity;
using EasyCore.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EasyCore.BLL
{
    public class DemoService : ServiceBase, IDemoService
    {

        public List<DemoViewPerson> DemoDoSomeThing(Expression<Func<DemoViewPerson, bool>> lambda = null)
        {

            IQuery<DemoName> demoNameQ = DbContext.Query<DemoName>();
            IQuery<DemoAge> demoAgeQ = DbContext.Query<DemoAge>();

            IQuery<DemoViewPerson> demoPersonQ =
                demoNameQ.LeftJoin(demoAgeQ, (x, y) => x.ID == y.ID)
                .Select(
                    (x, y) => new DemoViewPerson
                    {
                        ID = x.ID,
                        Name = x.Name,
                        Age = y.Age
                    });

            demoPersonQ = demoPersonQ.Where(lambda);



            List<DemoViewPerson> demoPersonList = demoPersonQ.ToList();

            return demoPersonList;

        }

    }

}
