using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLayer.Core.DTOs;
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
    }
}
