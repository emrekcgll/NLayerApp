using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Entities;
using NLayer.Core.Repository;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;

namespace NLayer.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDTO<CategoryWithProductsDTO>> GetCategoryByIdWithProducts(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdWithProducts(id);
            var categoryDTO = _mapper.Map<CategoryWithProductsDTO>(category);
            return CustomResponseDTO<CategoryWithProductsDTO>.Success(200, categoryDTO);
        }
    }
}
