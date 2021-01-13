/*-------------------------------------------------------------------------
 * 作者：WuTian
 * 版本号：v1.0
 * 本类主要用途描述及食用方式：
 * 业务层服务实例,继承服务基类和本服务的接口
 * DbContext在ServiceBase中构造
 *  -------------------------------------------------------------------------*/
using EasyCore.Entity;
using Microsoft.EntityFrameworkCore;


namespace EasyCore.BLL
{
    public class DemoService : ServiceBase, IDemoService
    {

        /// <summary>
        /// DEMO业务
        /// </summary>
        public void DemoDoSomeThing()
        {
   

            //使用EF 进行业务操作
            using (DbContext)
            {


                DbSet<LY_INTELLECT_SUPPUPLOADFILE> thisSet = DbContext.Set<LY_INTELLECT_SUPPUPLOADFILE>();


             
            }

     

        }
    }
}
