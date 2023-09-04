using Microsoft.EntityFrameworkCore;
using NLayer.Core.Entities;
using NLayer.Core.Repository;

namespace NLayer.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(Context context) : base(context)
        {
        }

        public async Task<List<Product>> GetProductsWithCategory()
        {
            return await _context.Products.Include(p => p.Category).ToListAsync();
        }
    }
}
