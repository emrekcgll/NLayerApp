using Microsoft.EntityFrameworkCore;
using NLayer.Core.Entities;
using NLayer.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(Context context) : base(context)
        {
        }

        public async Task<Category> GetCategoryByIdWithProducts(int id)
        {
            return await _context.Categories.Include(x => x.Products).Where(x => x.Id == id).SingleOrDefaultAsync();
        }
    }
}
