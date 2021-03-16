using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EasyCore.BLL;
using EasyCore.Unity;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace EasyCore.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddControllersWithViews().AddNewtonsoftJson();


            #region 业务层依赖注入

            //DEMO业务层
            services.AddScoped(typeof(IDemoService), typeof(DemoService));


            #endregion


            #region 配置管道过滤器

            //报错格式化
            services.AddControllersWithViews(options => {
                options.Filters.Add(typeof(ErrorCatchAttribute));
            });
            //参数校验
            services.AddControllersWithViews(options => {
                options.Filters.Add(typeof(ParaModelValidateAttribute));
            });
            #endregion



            #region JsonWebToken服务相关

            //JsonWebToken服务
            services.AddScoped(typeof(ITokenHelper), typeof(TokenHelper));

            //读取配置文件配置的jwt相关配置
            services.Configure<JwtConfig>(Configuration.GetSection("JWT"));

            //启用JWT
            services.AddAuthentication(Options =>
            {
                Options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                Options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).

            AddJwtBearer();

            #endregion

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            //启用认证中间件
            app.UseAuthentication();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "api/{controller=Home}/{action=Index}/{Id?}"
                    );
            });

        }
    }
}
