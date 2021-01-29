using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EasyCore.BLL;

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


            #region ÅäÖÃÒÀÀµ×¢Èë

            services.AddScoped(typeof(IDemoService), typeof(DemoService));

            #endregion


            #region ÅäÖÃÄ¬ÈÏ¹ýÂËÆ÷
            services.AddControllersWithViews(options => {
                options.Filters.Add(typeof(ErrorCatchAttribute));
            });
            services.AddControllersWithViews(options => {
                options.Filters.Add(typeof(ParaModelValidateAttribute));
            });
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

            app.UseAuthorization();

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
