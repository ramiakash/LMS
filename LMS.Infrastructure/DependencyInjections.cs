using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LMS.Application.Core.Services;
using LMS.Domain.Core.Repositories;
using LMS.Infrastructure.Data;
using LMS.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using LMS.Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using LMS.Application.Interfaces;
using LMS.Application.Services;

namespace LMS.Infrastructure
{
    public static class DependencyInjections
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration Configuration)
        {



            services.AddDbContext<LMSDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("LMSDatabase")));

            //Add Identity 
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<LMSDbContext>()
                .AddSignInManager();
            // .AddRoleManager<IdentityRole>();
            //Add authantication 
            services.AddAuthentication(
                options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(options =>
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]!))
                }
                );
            //Add Authorization 
            services.AddAuthorizationBuilder();

            services.AddScoped(typeof(IBaseRepositoryAsync<>), typeof(BaseRepositoryAsync<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserAccount, UserAccount>();


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