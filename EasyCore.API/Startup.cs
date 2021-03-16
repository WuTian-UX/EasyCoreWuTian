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


            #region ҵ�������ע��

            //DEMOҵ���
            services.AddScoped(typeof(IDemoService), typeof(DemoService));


            #endregion


            #region ���ùܵ�������

            //�����ʽ��
            services.AddControllersWithViews(options => {
                options.Filters.Add(typeof(ErrorCatchAttribute));
            });
            //����У��
            services.AddControllersWithViews(options => {
                options.Filters.Add(typeof(ParaModelValidateAttribute));
            });
            #endregion



            #region JsonWebToken�������

            //JsonWebToken����
            services.AddScoped(typeof(ITokenHelper), typeof(TokenHelper));

            //��ȡ�����ļ����õ�jwt�������
            services.Configure<JwtConfig>(Configuration.GetSection("JWT"));

            //����JWT
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

            //������֤�м��
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
