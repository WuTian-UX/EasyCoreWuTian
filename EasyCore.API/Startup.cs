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


            #region ҵ�������ע��

            //DEMOҵ���
            services.AddScoped(typeof(IDemoService), typeof(DemoService));


            #endregion


            #region ����Ĭ�Ͽ����Ĺܵ�������

            //�����ʽ��
            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(typeof(ErrorCatchAttribute));
            });
            //����У��
            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(typeof(ParaModelValidateAttribute));
            });
            //JWTУ��
            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(typeof(JsonWebTokenValidateAttribute));
            });

            #endregion


            #region JsonWebToken�������

            //JsonWebToken��������ע��
            services.AddScoped(typeof(ITokenService), typeof(TokenService));

            //��ȡ�����ļ����õ�JsonWebToken�������
            services.Configure<JwtConfig>(Configuration.GetSection("JsonWebToken"));

            //����JsonWebToken
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

            //��Ȩ�м��
            //app.UseAuthorization();

            //ʹ����֤�м��
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
