using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApiBook.BusinessLayer.Abstract;
using MyApiBook.EntityLayer.Concrete;
using System.Text.Json.Serialization;
using System.Text.Json;
using MyApiBook.WebApi.Dtos;

namespace MyApiBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ArticleController : ControllerBase
	{
		private readonly IArticleService _articleService;

		public ArticleController(IArticleService articleService)
		{
			_articleService = articleService;
		}

		[HttpGet]
		public IActionResult ArticleList()
		{
			var values = _articleService.TGetAll();
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateArticle(CreateArticleApiDto  createArticleApiDto)
		{
            var article = new Article
            {
				
                AuthorID = createArticleApiDto.AuthorID,
                CreatedDate = createArticleApiDto.CreatedDate,
				Description = createArticleApiDto.Description
            };

            _articleService.TInsert(article);
            return Ok("Ekleme Başarılı");
        }
		[HttpDelete]
		public IActionResult ArticleBook(int id)
		{
			_articleService.TDelete(id);
			return Ok("Silme Başarılı");
		}
		[HttpGet("GetArticle")]
		public IActionResult GetArticle(int id)
		{
			var value = _articleService.TGetByID(id);
			return Ok(value);
		}
		[HttpPut]
		public IActionResult UpdateArticle(UpdateArticleApiDto updateArticleApiDto)
		{
            var article = new Article
            {
				ArticleID = updateArticleApiDto.ArticleID,
                AuthorID = updateArticleApiDto.AuthorID,
                CreatedDate = updateArticleApiDto.CreatedDate,
                Description = updateArticleApiDto.Description
            };
            _articleService.TUpdate(article);
			return Ok("Güncelleme Başarılı");
		}


		[HttpGet("ArticleWithAuthorAndBookList")]
		public IActionResult ArticleWithAuthorAndBookList()
		{
			var values = _articleService.TArticleWithAuthorAndBookList();

			var options = new JsonSerializerOptions
			{
				ReferenceHandler = ReferenceHandler.IgnoreCycles,


			};
			var json = JsonSerializer.Serialize(values, options);

			return Ok(json);

		}

	}
}
