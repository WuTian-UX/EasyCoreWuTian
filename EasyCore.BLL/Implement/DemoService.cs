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

       

        public List<View_DemoPerson> DemoDoSomeThing(Expression<Func<View_DemoPerson, bool>> lambda = null)
        {
            List<View_DemoPerson> list = new List<View_DemoPerson>();
            using (DbContext)
            {

                IQuery<Demo_Name> query_DemoName = DbContext.Query<Demo_Name>();
                IQuery<Demo_Age> query_DemoAge = DbContext.Query<Demo_Age>();

                IQuery<View_DemoPerson> query_View_DemoPerson = query_DemoName.LeftJoin(query_DemoAge, (x, y) => x.ID == y.ID)
                    .Select((x, y) => new View_DemoPerson { ID = x.ID, Name = x.Name, Age = y.Age });

                if (lambda != null)
                {
                    query_View_DemoPerson = query_View_DemoPerson.Where(lambda);
                }


                list = query_View_DemoPerson.ToList();

            }
            return list;

        }





        public class SUPPUPLOADFILE_ViewModel
        {

            public string B_ID { get; set; }


            public int TYPE_ID { get; set; }


            public string FILE_NAME { get; set; }
        }

        public class Demo_Person
        {

            public string ID { get; set; }

            public string Name { get; set; }

            public string Age { get; set; }



        }



    }
}
