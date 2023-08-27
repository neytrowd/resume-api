using ResumeApi.Services.Resume;

namespace ResumeApi.Configuration
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IResumeService, ResumeService>();

            return services;
        }
    }
}