/*-------------------------------------------------------------------------
 * 作者：WuTian
 * 版本号：v1.0
 * 本类主要用途描述及食用方式：
 * ORACLE使用的DbContext
 * 往下加实体
 *  -------------------------------------------------------------------------*/
using Microsoft.EntityFrameworkCore;
using EasyCore.Entity;

namespace EasyCore.DA
{
    public class OracleContextEF : DbContext
    {
        public OracleContextEF(DbContextOptions<OracleContextEF> options) : base(options)
        { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            string PROTOCOL = AppConfigurtaionServices.Configuration["OracleSettings:PROTOCOL"];
            string HOST = AppConfigurtaionServices.Configuration["OracleSettings:HOST"];
            string PORT = AppConfigurtaionServices.Configuration["OracleSettings:PORT"];
            string SERVICE_NAME = AppConfigurtaionServices.Configuration["OracleSettings:SERVICE_NAME"];
            string UserId = AppConfigurtaionServices.Configuration["OracleSettings:UserId"];
            string Password = AppConfigurtaionServices.Configuration["OracleSettings:Password"];
            optionsBuilder.UseOracle(
                "Data Source = (DESCRIPTION = (ADDRESS = (PROTOCOL = " + PROTOCOL + ")(HOST = " + HOST + ")(PORT = " + PORT + "))(CONNECT_DATA = (SERVICE_NAME = " + SERVICE_NAME + "))); User Id = " + UserId + "; Password = " + Password + "; ");


            base.OnConfiguring(optionsBuilder);
        }


        //实体


        public DbSet<Demo_Age> Demo_Age { get; set; }
        public DbSet<Demo_Name> Demo_Name { get; set; }
    }
}
