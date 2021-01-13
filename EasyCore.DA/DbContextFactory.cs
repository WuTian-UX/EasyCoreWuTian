/*-------------------------------------------------------------------------
 * 作者：WuTian
 * 版本号：v1.0
 * 本类主要用途描述及食用方式：
 * DbContext工厂类
 *  -------------------------------------------------------------------------*/
using Microsoft.EntityFrameworkCore;

namespace EasyCore.DA
{
    public class DbContextFactory
    {

        public static DbContext CreateContext()
        {


            DbContext dbContext = null;

            string dbType = AppConfigurtaionServices.Configuration["ServerType"];

            switch (dbType)
            {
                case "sqlserver":
                    //dbContext = CreateSqlServerContext();
                    break;
                case "mysql":
                    //dbContext = CreateMySqlContext();
                    break;
                case "oracle":
                    dbContext = CreateOracleContext();
                    break;
            }

            return dbContext;
        }



        #region 创建dbContext


        /// <summary>
        /// 创建ORACLE Dbcontext
        /// </summary>
        /// <returns></returns>
        static DbContext CreateOracleContext()
        {

            DbContextOptions<OracleContext> options = new DbContextOptions<OracleContext>();

            OracleContext oracleContext = new OracleContext(options);


            return oracleContext;
        }



        static DbContext CreateMySQLContext()
        {

            DbContextOptions<MySQLContext> options = new DbContextOptions<MySQLContext>();
            MySQLContext mySQLContext = new MySQLContext(options);
            return mySQLContext;
        }

        #endregion
    }
}
