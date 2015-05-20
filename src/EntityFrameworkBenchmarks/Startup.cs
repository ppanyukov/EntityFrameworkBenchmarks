using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.DependencyInjection;
using EntityFrameworkBenchmarks.Data;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Diagnostics;

namespace EntityFrameworkBenchmarks
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
        }

        // This method gets called by a runtime.
        // Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Add EF services to the services container.
            // Doing this as per MusicStore example for EF 7 here: https://github.com/aspnet/MusicStore/blob/master/src/MusicStore/Startup.cs
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<EfDbContext>(options =>
                    options.UseSqlServer(Config.ConnectionString));

            services.AddSingleton(typeof(DapperDbContext));
            services.AddSingleton(typeof(ManualDbContext));

            services.AddMvc();
            // Uncomment the following line to add Web API services which makes it easier to port Web API 2 controllers.
            // You will also need to add the Microsoft.AspNet.Mvc.WebApiCompatShim package to the 'dependencies' section of project.json.
            // services.AddWebApiConventions();
        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseErrorPage(ErrorPageOptions.ShowAll);

            // Add MVC to the request pipeline.
            app.UseMvc();
            // Add the following route for porting Web API 2 controllers.
            // routes.MapWebApiRoute("DefaultApi", "api/{controller}/{id?}");
        }
    }
}
