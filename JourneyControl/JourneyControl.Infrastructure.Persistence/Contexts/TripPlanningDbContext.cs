using JourneyControl.Infrastructure.Persistence.Entities.TripPlanning;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;
using System.Reflection;

namespace JourneyControl.Infrastructure.Persistence.Contexts
{
    public class TripPlanningDbContext : DbContext
    {
        public TripPlanningDbContext(DbContextOptions<TripPlanningDbContext> options)
            : base(options)
        {
        }

        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var type = typeof(IEntityTypeConfiguration<>);
            var typeConfigurations = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => 
                    !string.IsNullOrEmpty(x.Namespace) && x.Namespace.Contains("Entities.TripPlanning") &&
                    x.GetInterfaces().Any(y => y.IsGenericType && y.Name == type.Name)).ToList();

            foreach (var configuration in typeConfigurations)
            {
                dynamic configurationInstance = Activator.CreateInstance(configuration);
                builder.ApplyConfiguration(configurationInstance);
            }

            base.OnModelCreating(builder);
        }

        public IDbConnection Connection => this.Database.GetDbConnection();
    }
}
