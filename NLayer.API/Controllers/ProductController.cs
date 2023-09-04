using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Entities;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IService<Product> _service;
        public ProductController(IMapper mapper, IService<Product> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAllAsync();
            var productsDTO = _mapper.Map<List<ProductDTO>>(products.ToList());
            return Ok(productsDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            var productDTO = _mapper.Map<ProductDTO>(product);
            return Ok(productDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDTO dto)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(dto));
            var productDTO = _mapper.Map<ProductDTO>(product);

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, productDTO);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductDTO dto)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(dto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(product);
            return NoContent();
        }
    }
}
