using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApiBook.BusinessLayer.Abstract;
using MyApiBook.EntityLayer.Concrete;
using MyApiBook.WebApi.Dtos;

namespace MyApiBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriterController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public WriterController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public IActionResult WriterList()
        {
            var value = _authorService.TGetAll();
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateWriter(CreateAuthorApiDto createAuthorApiDto)
        {

            var author = new Author
            {

                AuthorName = createAuthorApiDto.AuthorName,
                AuthorSurname = createAuthorApiDto.AuthorSurname
            };

            _authorService.TInsert(author);

            return Ok("Ekleme Başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteWriter(int id)
        {
            _authorService.TDelete(id);
            return Ok("Silme Başarılı");
        }

        [HttpGet("GetWriter")]
        public IActionResult GetWriter(int id)
        {
            var value = _authorService.TGetByID(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateWriter(UpdateAuthorApiDto updateAuthorApiDto)
        {

            var author = new Author
            {
                AuthorID = updateAuthorApiDto.AuthorID,
                AuthorName = updateAuthorApiDto.AuthorName,
                AuthorSurname = updateAuthorApiDto.AuthorSurname
            };

            _authorService.TUpdate(author);

            return Ok("Güncelleme Başarılı");
        }

    }
}
