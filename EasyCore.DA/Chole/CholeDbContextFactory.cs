/*-------------------------------------------------------------------------
 * 作者：WuTian
 * 版本号：v1.0
 * 本类主要用途描述及食用方式：
 * 
 *  -------------------------------------------------------------------------*/
using Chloe;
using Chloe.Oracle;
using EasyCore.Unity;

namespace EasyCore.DA
{
    public static class CholeDbContextFactory
    {
        public static IDbContext CreateContext()
        {
            IDbContext dbContext = null;

            string dbType = AppConfigurtaionServices.Configuration["ServerType"];

            switch (dbType)
            {

                //case "mysql":
                //    dbContext = CreateMySQLContext();
                //    break;
                case "oracle":
                    dbContext = CreateOracleContext();
                    break;
            }

            return dbContext;
        }



        static IDbContext CreateOracleContext()
        {
            OracleContext dbContext = new OracleContext(new OracleConnectionFactory());
            return dbContext;
        }
    }
}
