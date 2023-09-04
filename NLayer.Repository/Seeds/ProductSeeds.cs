using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Entities;

namespace NLayer.Repository.Seeds
{
    public class ProductSeeds : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product { Id = 1, CategoryId = 1, Name = "Kalem 1.1", Price = 10, Stock = 20, CreatedDate = DateTime.Now },
                            new Product { Id = 2, CategoryId = 1, Name = "Kalem 1.2", Price = 30, Stock = 20, CreatedDate = DateTime.Now },
                            new Product { Id = 3, CategoryId = 1, Name = "Kalem 1.3", Price = 20, Stock = 20, CreatedDate = DateTime.Now },
                            new Product { Id = 4, CategoryId = 2, Name = "Kitap 1.1", Price = 40, Stock = 20, CreatedDate = DateTime.Now });
        }
    }
}
