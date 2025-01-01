using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApiBook.BusinessLayer.Abstract;
using MyApiBook.EntityLayer.Concrete;
using MyApiBook.WebApi.Dtos;

namespace MyApiBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var value = _categoryService.TGetAll();
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryApiDto createCategoryApiDto)
        {
         
            var category = new Category
            {
               
                CategoryName = createCategoryApiDto.CategoryName
            };

             _categoryService.TInsert(category);

            return Ok("Ekleme Başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.TDelete(id);
            return Ok("Silme Başarılı");
        }

        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            var value = _categoryService.TGetByID(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryApiDto updateCategoryApiDto)
        {

            var category = new Category
            {
                CategoryID = updateCategoryApiDto.CategoryID,
                CategoryName = updateCategoryApiDto.CategoryName
            };

            // TInsert metoduna Category nesnesini gönder
            _categoryService.TUpdate(category);

            return Ok("Güncelleme Başarılı");
        }
       
		
	}
}
