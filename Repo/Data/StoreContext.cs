using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repo.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            if(Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                foreach (var item in modelBuilder.Model.GetEntityTypes())
                {
                    var props = item.ClrType.GetProperties().Where(p => p.PropertyType == typeof(decimal));
                    foreach (var prop in props)
                    {
                        modelBuilder.Entity(item.Name).Property(prop.Name).HasConversion<double>();
                    }
                }
            }
        }
    }
}