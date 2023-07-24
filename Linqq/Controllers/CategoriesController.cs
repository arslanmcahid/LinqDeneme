using AutoMapper;
using Core.DTOs;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Linqq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(CategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _categoryService.GetAllCategories();
            var categoryDtos = _mapper.Map<List<CategoryDto>>(categories);
            return Ok(categoryDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }

            var categoryDto = _mapper.Map<CategoryDto>(category);
            return Ok(categoryDto);
        }

        [HttpPost]
        public IActionResult AddCategory(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            _categoryService.AddCategory(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, categoryDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, CategoryDto categoryDto)
        {
            var existingCategory = _categoryService.GetCategoryById(id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            var category = _mapper.Map<Category>(categoryDto);
            category.Id = id;
            _categoryService.UpdateCategory(category);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }

            _categoryService.DeleteCategory(category);
            return NoContent();
        }
    }
}
