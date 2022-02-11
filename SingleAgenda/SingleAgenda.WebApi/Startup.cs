using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SingleAgenda.EFPersistence.Configuration;
using SingleAgenda.Infra.IoC.Application;
using SingleAgenda.Infra.IoC.Security;

namespace SingleAgenda.WebApi
{
    public class Startup
    {

        readonly string corsSpecificationOrigins = "_corsSpecificationOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            this.CorsSetup(services);
            services.AddDbContext<SingleAgendaDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddControllers();
            services.AddBusiness(this.Configuration);

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(corsSpecificationOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseMiddleware<JwtMiddleware>();
        }

        private void CorsSetup(IServiceCollection services)
        {
            var angularPortalUrl = Configuration["AngularPortalUrl"];

            services.AddCors(options =>
            {
                options.AddPolicy(name: corsSpecificationOrigins,
                    builder =>
                    {
                        builder.WithOrigins(
                            angularPortalUrl
                        )
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                    });
            });
        }
    }
}
