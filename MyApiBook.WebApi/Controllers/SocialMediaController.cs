using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApiBook.BusinessLayer.Abstract;
using MyApiBook.EntityLayer.Concrete;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace MyApiBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService  _socialMediaService;

        public SocialMediaController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var values = _socialMediaService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(SocialMedia socialMedia)
        {
            _socialMediaService.TInsert(socialMedia);
            return Ok("Ekleme Başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteSocialMedia(int id)
        {
            _socialMediaService.TDelete(id);
            return Ok("Silme Başarılı");
        }
        [HttpGet("GetSocialMedia")]
        public IActionResult GetSocialMedia(int id)
        {
            var value = _socialMediaService.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateSocialMedia(SocialMedia socialMedia)
        {
            _socialMediaService.TUpdate(socialMedia);
            return Ok("Güncelleme Başarılı");
        }
     

    

    }
}
