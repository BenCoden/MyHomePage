using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using MyHomePage.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MyHomePage.Data;
using MyHomePage.EntityFrameworkCoreSQL;

using MyHomePage.EntityFrameworkCoreSQL.dbObjects;
using Blazor.ModalDialog;

namespace MyHomePage
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            GetDependencyServices(services);
        }

        private void GetDependencyServices(IServiceCollection services)
        {//ui
            services.AddBlazorContextMenu();
            services.AddModalDialog();

            //db
            services.AddDbContext<AppDbContext>(op =>//
            op.UseSqlServer(Configuration.GetConnectionString("OneContext")));
            services.AddScoped<ITRepo<dboLinks>, TRepo<dboLinks>>();
            services.AddScoped<ITRepo<dboSearchProviders>, TRepo<dboSearchProviders>>();
            //logic
            services.AddScoped<IMyLinks, MyLinks>();
            services.AddScoped<IMySearchProvider, MySearchProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}