using AutoMapper;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLayer.Core.DTOs;
using NLayer.Core.Entities;
using NLayer.Repository;

namespace NLayer.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public ProductController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var productsWithCategory = await _context.Products.Include(x => x.Category).ToListAsync();
            var productsWithCategoryDTO = _mapper.Map<List<ProductWithCategoryDTO>>(productsWithCategory);
            return View(productsWithCategoryDTO);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _context.Products.FindAsync(id);
            var productDTO = _mapper.Map<ProductDTO>(product);
            return View(productDTO);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Remove(product);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductDTO dto)
        {
            await _context.AddAsync(_mapper.Map<Product>(dto));
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var existingProduct = await _context.Products.FindAsync(id);
            var existingProductDTO= _mapper.Map<ProductDTO>(existingProduct);
            return View(existingProductDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductDTO dto)
        {
            var existingProduct = await _context.Products.FindAsync(dto.Id);
            _mapper.Map<ProductDTO>(existingProduct); //_mapper.Map(dto, existingProduct);
            _context.Update(existingProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
