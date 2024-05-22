using Microsoft.Extensions.DependencyInjection;
using LMS.Application.Interfaces;
using LMS.Application.Services;

namespace LMS.Application
{
    public static class DependencyInjections
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICourseService, CourseService>();
        }
    }
}