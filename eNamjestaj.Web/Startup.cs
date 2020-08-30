using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using eNamjestaj.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using eNamjestaj.Data.Helper;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace eNamjestaj.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<MojContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("lokalni")));
            //services.AddDbContext<MojContext>(x => x.UseSqlServer(Configuration.GetConnectionString("lokalni")));

            services.AddSingleton<IFileProvider>(
                new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMvc(options =>
            {
            }).AddSessionStateTempDataProvider();
            services.AddDistributedMemoryCache();
            services.AddSession();
            //services.AddHttpContextAccessor();
            //services.AddScoped<IUserSession, UserSession>();
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
           // services.AddScoped<TestManager>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseSession();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
