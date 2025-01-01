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
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public IActionResult BookList()
        {
            var values = _bookService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBook(CreateBookApiDto createBookApiDto)
        {

            var book = new Book
            {

                Name = createBookApiDto.Name,
                CreatedDate = createBookApiDto.CreatedDate,
                OrginalPrice = createBookApiDto.OrginalPrice,
                ImageUrl = createBookApiDto.ImageUrl,
                Description = createBookApiDto.Description,
                AuthorID = createBookApiDto.AuthorID,
                CategoryID = createBookApiDto.CategoryID
            };

            
            _bookService.TInsert(book);

            return Ok("Ekleme Başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            _bookService.TDelete(id);
            return Ok("Silme Başarılı");
        }
        [HttpGet("GetBook")]
        public IActionResult GetBook(int id)
        {
            var value = _bookService.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateBook(UpdateBookApiDto updateBookApiDto)
        {
            var book = new Book
            {
             BookID = updateBookApiDto.BookID,
             OrginalPrice = updateBookApiDto.OrginalPrice,
             ImageUrl = updateBookApiDto.ImageUrl,
             Description = updateBookApiDto.Description,
             Name = updateBookApiDto.Name,
             AuthorID = updateBookApiDto.AuthorID,
             CategoryID = updateBookApiDto.CategoryID,
             CreatedDate = updateBookApiDto.CreatedDate

            };

            _bookService.TUpdate(book);
            return Ok("Güncelleme Başarılı");
        }
        [HttpGet("BookCount")]
        public IActionResult BookCount()
        {
            return Ok(_bookService.TGetBookCount());
        }

		[HttpGet("CategoryWithBooksAndAuthor")]
		public IActionResult CategoryWithBooks(int id)
		{
			var values = _bookService.TBookWithCategoryAndAuthorList(id);

			var options = new JsonSerializerOptions
			{
				ReferenceHandler = ReferenceHandler.IgnoreCycles,
				
			};

			var json = JsonSerializer.Serialize(values, options);

			return Ok(json); 
		}

		[HttpGet("CategoryBooksAndAuthorList")]
		public IActionResult CategoryBooksAndAuthorList()
		{
			var values = _bookService.TBookWithCategoryAndAuthorList();

			var options = new JsonSerializerOptions
			{
				ReferenceHandler = ReferenceHandler.IgnoreCycles,

			};

			var json = JsonSerializer.Serialize(values, options);

			return Ok(json);
		}

		[HttpGet("BookWithAuthor")]
        public IActionResult BookWithAuthor()
        {
            var values = _bookService.TBookWithAuthorList();

			var options = new JsonSerializerOptions
			{
				ReferenceHandler = ReferenceHandler.IgnoreCycles,
			

			};
			var json = JsonSerializer.Serialize(values, options);

			return Ok(json);
		
        }

	}
}
