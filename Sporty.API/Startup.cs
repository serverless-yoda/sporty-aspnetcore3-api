using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;



using Sporty.Infrastructure.Data;
using Sporty.Infrastructure.IoC;

namespace Sporty.API
{
    public class Startup
    {

        public static void RegisterServices(IServiceCollection services)
        {
            DIContainer.RegisterServices(services);
        }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddDbContext<SportyContext>(option => option.UseInMemoryDatabase("SportyShop"));
            services.AddControllers().ConfigureApiBehaviorOptions(option =>
            {
                //supress ModelState.IsValid
                //option.SuppressModelStateInvalidFilter = true;
            });

            //services.AddAuthentication("Bearer")
            //    .AddJwtBearer("Bearer", options =>
            //    {
            //        //taken from IdentityProvider
            //        options.Authority = "http://localhost:51783";
            //        options.RequireHttpsMetadata = false;
            //        options.Audience = "sporty-api";
            //    });

            //add versioning
            services.AddApiVersioning(option =>
            {
                option.ReportApiVersions = true;
                option.DefaultApiVersion = new ApiVersion(2, 0);
                option.AssumeDefaultVersionWhenUnspecified = true;

                //using HttpHeader versioning
                //option.ApiVersionReader = new HeaderApiVersionReader("X-API-Version")
            });

            //cors sample builder template
            //services.AddCors(option =>
            //{
            //    option.AddDefaultPolicy(builder =>
            //    {
            //        builder.WithOrigins("<put https link here>")
            //        .AllowAnyHeader()
            //        .AllowAnyMethod();
            //    });
            //});


            //DIContainer
            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();
            //app.UseCors()

            app.UseAuthentication();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
            

        }
    }
}
