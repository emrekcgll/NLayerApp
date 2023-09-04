using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Entities;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomResponseProductController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductService _service;
        public CustomResponseProductController(IMapper mapper, IService<Product> service, IProductService productService)
        {
            _mapper = mapper;
            _service = productService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            return CreateActionResult(await _service.GetProductsWithCategory());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAllAsync();
            var productsDTO = _mapper.Map<List<ProductDTO>>(products.ToList());
            return CreateActionResult(CustomResponseDTO<List<ProductDTO>>.Success(200, productsDTO));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            var productDTO = _mapper.Map<ProductDTO>(product);
            return CreateActionResult(CustomResponseDTO<ProductDTO>.Success(200, productDTO));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDTO dto)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(dto));
            var productDTO = _mapper.Map<ProductDTO>(product);
            return CreateActionResult(CustomResponseDTO<ProductDTO>.Success(201, productDTO));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductDTO dto)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(dto));
            return CreateActionResult(CustomResponseDTO<ProductDTO>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(product);
            return CreateActionResult(CustomResponseDTO<ProductDTO>.Success(204));
        }
    }
}
