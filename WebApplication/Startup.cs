﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Extensions;
using DAL.Helpers;
using Domain.Identity;
using Identity;
using Interfaces;
using Interfaces.UOW;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApplication.Services;

namespace WebApplication
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see https://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IDataContext, ApplicationDbContext>();
            services.AddScoped<IRepositoryProvider, EFRepositoryProvider<IDataContext>>();
            services.AddSingleton<IRepositoryFactory, EFRepositoryFactory>();
            services.AddScoped<IUOW, UOW<IDataContext>>();


            services.AddMvc();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            var dataContext = app.ApplicationServices.GetService<ApplicationDbContext>();
            if (dataContext != null)
            {
                if (Configuration.GetValue<bool>("DropDatabaseAtStartup"))
                {
                    dataContext.Database.EnsureDeleted();
                }

                dataContext.Database.Migrate();
                dataContext.EnsureSeedData();
            }

            app.UseStaticFiles();

            app.UseIdentity();

            // create default roles and users
            app.EnsureDefaultUsersAndRoles();

            // Add external authentication middleware below. To configure them please see https://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areaIdentityUserRoutesroute",
                    template: "Identity/UserRoles/{action=Index}/{userId}/{roleId}",
                    defaults: new {area = "Identity", controller = "UserRoles"}
                );

                routes.MapRoute(
                    name: "arearoute",
                    template: "{area:exists}/{controller}/{action=Index}/{id?}",
                    defaults: new {controller = "Home"});

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
