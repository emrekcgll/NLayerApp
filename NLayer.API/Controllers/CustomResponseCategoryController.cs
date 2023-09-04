﻿using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomResponseCategoryController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;

        public CustomResponseCategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetCategoryByIdWithProducts(int id)
        {
            return CreateActionResult(await _categoryService.GetCategoryByIdWithProducts(id));
        }
    }
}
