using NLayer.Core.Entities;

namespace NLayer.Core.Repository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetCategoryByIdWithProducts(int id);
    }
}
