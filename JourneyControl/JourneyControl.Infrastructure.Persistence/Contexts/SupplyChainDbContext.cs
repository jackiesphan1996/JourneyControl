using System;
using System.Data;
using System.Linq;
using System.Reflection;
using JourneyControl.Infrastructure.Persistence.Entities.SupplyChain;
using Microsoft.EntityFrameworkCore;

namespace JourneyControl.Infrastructure.Persistence.Contexts
{
    public class SupplyChainDbContext : DbContext
    {
        public SupplyChainDbContext(DbContextOptions<SupplyChainDbContext> options)
            : base(options)
        {
        }

        public DbSet<BasketMovement> BasketMovements { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var type = typeof(IEntityTypeConfiguration<>);
            var typeConfigurations = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x =>
                    !string.IsNullOrEmpty(x.Namespace) &&  x.Namespace.Contains("Entities.SupplyChain") &&
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
