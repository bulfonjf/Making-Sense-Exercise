using ApplicationServices.Interfaces;
using ApplicationServices.Services;
using AutoMapper;
using BlogRepository;
using BlogRepository.Contexts;
using BlogRepository.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebAPI.MiddleWares;

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
            var connectionString = Configuration["ConnectionStrings:MySQLConnectionString"];
            services.AddDbContext<BlogContext>(o => o.UseMySQL(connectionString));
            RegisterAutomapperDependencies(services);
            services.AddScoped<IBlogServices, BlogServices>();
            services.AddScoped<IBlogRepository, MySQLBlogRepository>();
            services.AddControllers();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
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
