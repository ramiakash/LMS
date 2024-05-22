using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LMS.Application.Core.Services;
using LMS.Domain.Core.Repositories;
using LMS.Infrastructure.Data;
using LMS.Infrastructure.Repositories;
using LMS.Infrastructure.Services;

namespace LMS.Infrastructure
{
    public static class DependencyInjections
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<LMSDbContext>(options =>
                options.UseSqlServer("name=ConnectionStrings:LMSDatabase",
                x => x.MigrationsAssembly("LMS.Infrastructure")));

            services.AddScoped(typeof(IBaseRepositoryAsync<>), typeof(BaseRepositoryAsync<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ILoggerService, LoggerService>();
        }

        public static void MigrateDatabase(IServiceProvider serviceProvider)
        {
            var dbContextOptions = serviceProvider.GetRequiredService<DbContextOptions<LMSDbContext>>();
            
            using (var dbContext = new LMSDbContext(dbContextOptions))
            {
                dbContext.Database.Migrate();
            }
        }
    }
}