using Microsoft.EntityFrameworkCore;
using NLayer.Core.Entities;
using System.Reflection;

namespace NLayer.Repository
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            //modelBuilder.ApplyConfiguration(new ProductConfiguration());
            //modelBuilder.ApplyConfiguration(new ProductFeatureConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}