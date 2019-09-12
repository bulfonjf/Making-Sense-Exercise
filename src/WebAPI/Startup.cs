using ApplicationServices.Interfaces;
using ApplicationServices.Services;
using AutoMapper;
using BlogRepository;
using BlogRepository.Contexts;
using BlogRepository.Interfaces;
using WebAPI.MiddleWares;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace WebAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var connectionString = Configuration["ConnectionStrings:MySQLConnectionString"];
            services.AddDbContext<BlogContext>(o => o.UseMySQL(connectionString));
            RegisterAutomapperDependencies(services);
            services.AddScoped<IBlogServices, BlogServices>();
            services.AddScoped<IBlogRepository, MySQLBlogRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseAuthentication();
            //app.UseHttpsRedirection();
            app.UseMvc();
        }

        private static void RegisterAutomapperDependencies(IServiceCollection services)
        {
            var assembly = new string[] {System.Reflection.Assembly.GetExecutingAssembly().GetName().Name};
            var config = new MapperConfiguration(cfg => cfg.AddMaps(assembly));

            var mapper = config.CreateMapper();

            services.AddSingleton<IMapper>(mapper);
        }
    }
}
