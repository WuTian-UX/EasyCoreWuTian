/*-------------------------------------------------------------------------
 * 作者：WuTian
 * 版本号：v1.0
 * 本类主要用途描述及食用方式：
 * 要使用MySql，需要安装程序集MySql.Data.EntityFrameworkCore
 * 然后解除注释
 *  -------------------------------------------------------------------------*/
using Microsoft.EntityFrameworkCore;


namespace EasyCore.DA
{
    public class MySQLContext : DbContext
    {

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options)
        { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            //string HOST = AppConfigurtaionServices.Configuration["MySQLSettings:HOST"];
            //string DataBase = AppConfigurtaionServices.Configuration["MySQLSettings:DataBase"];
            //string UserId = AppConfigurtaionServices.Configuration["MySQLSettings:UserId"];
            //string Password = AppConfigurtaionServices.Configuration["MySQLSettings:Password"];

            //optionsBuilder.UseMySQL(
            //    "Server=" + HOST + ";Database=" + DataBase + ";Uid=" + UserId + ";Pwd=" + Password + ";");


            //base.OnConfiguring(optionsBuilder);
        }
    }
}
