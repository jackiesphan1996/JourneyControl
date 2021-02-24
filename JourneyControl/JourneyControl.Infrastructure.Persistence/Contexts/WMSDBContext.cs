using JourneyControl.Infrastructure.Persistence.Entities.WMSDB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;
using System.Reflection;

namespace JourneyControl.Infrastructure.Persistence.Contexts
{
    public class WMSDBContext : DbContext
    {
        public WMSDBContext(DbContextOptions<WMSDBContext> options)
            : base(options)
        {
        }

        public DbSet<AccountingBillingCheck> AccountingBillingChecks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var type = typeof(IEntityTypeConfiguration<>);
            var typeConfigurations = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x =>
                    !string.IsNullOrEmpty(x.Namespace) && x.Namespace.Contains("Entities.WMSDB") &&
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
