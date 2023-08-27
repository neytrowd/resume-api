using ResumeApi.Configuration;

namespace ResumeApi
{
    public class Startup
    {
        private readonly IConfiguration Configuration;
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddServicesConfiguration();
            services.AddSwaggerConfiguration();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSwaggerConfiguration();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}