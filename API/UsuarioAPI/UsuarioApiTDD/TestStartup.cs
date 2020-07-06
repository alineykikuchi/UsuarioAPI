using JuntoSeguros.Models.ConfigurationSettings;
using JuntoSeguros.Models.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using UsuarioAPI;
using UsuarioAPI.Extension;
using UsuarioAPI.Services;

namespace UsuarioApiTDD
{
    public class TestStartup : Startup
    {
        public new IConfiguration Configuration { get; }

        public TestStartup(IHostingEnvironment env, IConfiguration cn) : base(cn)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();

            Configuration = builder.Build();

        }

        

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddDbContext<ConfigureModelsDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("StringConnection")));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            ConfigureTypesBusiness.RegisterAllTypesBusiness(services);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public override void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
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
            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseGlobalExceptionHandler(loggerFactory);
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
