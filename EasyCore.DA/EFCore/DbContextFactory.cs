/*-------------------------------------------------------------------------
 * 作者：WuTian
 * 版本号：v1.0
 * 本类主要用途描述及食用方式：
 * DbContext工厂类(EF用的)
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
                
                case "mysql":
                    dbContext = CreateMySQLContext();
                    break;
                case "oracle":
                    dbContext = CreateOracleContext();
                    break;
            }

            return dbContext;
        }



        #region 创建EF用的 dbContext


        /// <summary>
        /// 创建ORACLE Dbcontext
        /// </summary>
        /// <returns></returns>
        static DbContext CreateOracleContext()
        {

            DbContextOptions<OracleContextEF> options = new DbContextOptions<OracleContextEF>();
            OracleContextEF oracleContext = new OracleContextEF(options);
            return oracleContext;
        }


        /// <summary>
        /// 创建MySQL Dbcontext
        /// </summary>
        /// <returns></returns>
        static DbContext CreateMySQLContext()
        {

            DbContextOptions<MySQLContext> options = new DbContextOptions<MySQLContext>();
            MySQLContext mySQLContext = new MySQLContext(options);
            return mySQLContext;
        }

        #endregion

   
    }
}
