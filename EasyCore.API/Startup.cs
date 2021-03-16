using EasyCore.BLL;
using EasyCore.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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


            #region 配置默认开启的管道过滤器

            //报错格式化
            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(typeof(ErrorCatchAttribute));
            });
            //参数校验
            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(typeof(ParaModelValidateAttribute));
            });
            //JWT校验
            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(typeof(JsonWebTokenValidateAttribute));
            });

            #endregion


            #region JsonWebToken服务相关

            //JsonWebToken服务依赖注入
            services.AddScoped(typeof(ITokenService), typeof(TokenService));

            //读取配置文件配置的JsonWebToken相关配置
            services.Configure<JwtConfig>(Configuration.GetSection("JsonWebToken"));

            //启用JsonWebToken
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

            //授权中间件
            //app.UseAuthorization();

            //使用认证中间件
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
