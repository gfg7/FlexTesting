using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Folder;
using FlexTesting.Core.Contract.Issue;
using FlexTesting.Core.Contract.Source;
using FlexTesting.Core.Contract.TaskStatus;
using FlexTesting.Core.Contract.Token;
using FlexTesting.Core.Contract.User;
using FlexTesting.Core.Folder;
using FlexTesting.Core.Issue;
using FlexTesting.Core.Source;
using FlexTesting.Core.TaskStatus;
using FlexTesting.Core.Token;
using FlexTesting.Core.User;
using FlexTesting.WebApp.Commands;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FlexTesting.WebApp
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
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                });
            services.AddAuthorization();
            services.AddControllersWithViews();
            
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserGetOperations, UserGetOperations>();
            services.AddScoped<IUserWriteOperations, UserWriteOperations>();

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ITokenGetOperations, TokenGetOperations>();
            services.AddScoped<ITokenWriteOperations, TokenWriteOperations>();
            
            services.AddScoped<IFolderService, FolderService>();
            services.AddScoped<IFolderGetOperations, FolderGetOperations>();
            services.AddScoped<IFolderWriteOperations, FolderWriteOperations>();
            
            services.AddScoped<ITaskStatusService, TaskStatusService>();
            services.AddScoped<ITaskStatusGetOperations, StatusGetOperations>();
            services.AddScoped<ITaskStatusWriteOperations, StatusWriteOperations>();
            
            services.AddScoped<IIssueService, IssueService>();
            services.AddScoped<IIssueGetOperations, IssueGetOperations>();
            services.AddScoped<IIssueWriteOperations, IssueWriteOperations>();

            services.AddScoped<ISourceGetOperations, SourceGetDbOperations>();
            services.AddScoped<ConstructMainPageCommand>();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCookiePolicy();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}