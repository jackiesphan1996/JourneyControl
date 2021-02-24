using JourneyControl.Infrastructure.Identity.Contexts;
using JourneyControl.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JourneyControl.Infrastructure.Identity
{
    public static class ServiceExtensions
    {
        public static void AddIdentityInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentityContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("TripPlanningDbConnection"),
                    b => b.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            services.AddAuthorization();

            services.AddAuthentication();
        }
    }
}
