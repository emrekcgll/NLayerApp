using NLayer.Core.Entities;

namespace NLayer.Core.Repository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetProductsWithCategory();
    }
}
