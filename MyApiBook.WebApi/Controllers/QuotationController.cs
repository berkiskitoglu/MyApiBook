using Microsoft.AspNetCore.Mvc;
using MyApiBook.BusinessLayer.Abstract;
using MyApiBook.EntityLayer.Concrete;
using MyApiBook.WebApi.Dtos;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace MyApiBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotationController : Controller
    {
        private readonly IQuotationService _quotationService;

        public QuotationController(IQuotationService quotationService)
        {
            _quotationService = quotationService;
        }

   
        [HttpGet]
        public IActionResult QuotationList()
        {
            var value = _quotationService.TGetAll();
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateQuotation(CreateQuotationApiDto createQuotationApiDto)
        {

            var quotation = new Quotation
            {

               AuthorID  = createQuotationApiDto.AuthorID,
               Description = createQuotationApiDto.Description
            };

            _quotationService.TInsert(quotation);

            return Ok("Ekleme Başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteQuotation(int id)
        {
            _quotationService.TDelete(id);
            return Ok("Silme Başarılı");
        }

        [HttpGet("GetQuotation")]
        public IActionResult GetQuotation(int id)
        {
            var value = _quotationService.TGetByID(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateQuotation(UpdateQuotationApiDto updateQuotationApiDto)
        {

            var quotation = new Quotation
            {
                QuatationID = updateQuotationApiDto.QuatationID,
                AuthorID = updateQuotationApiDto.AuthorID,
                Description = updateQuotationApiDto.Description
            };

            // TInsert metoduna Category nesnesini gönder
            _quotationService.TUpdate(quotation);

            return Ok("Güncelleme Başarılı");
        }

        [HttpGet("QuotationWithAuthor")]
        public IActionResult QuotationWithAuthor()
        {
            var values = _quotationService.TQuatationWithAuthor();

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,

            };
            return Ok(values);
        }

    }
}
