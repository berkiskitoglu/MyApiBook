using Microsoft.AspNetCore.Mvc;
using MyApiBook.WebUI.Dtos;
using Newtonsoft.Json;
using System.Text;

namespace MyApiBook.WebUI.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ArticleController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ArticleList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7079/api/Article");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultArticleDto>>(jsonData);
                
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateArticle()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateArticle(CreateArticleDto createArticleDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createArticleDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var ResponseMessage = await client.PostAsync("https://localhost:7079/api/Article", stringContent);
            if (ResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ArticleList");
            }
            return View();
        }

        public async Task<IActionResult> DeleteArticle(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7079/api/Article?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ArticleList");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateArticle(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7079/api/Article/GetArticle?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateArticleDto>(jsonData);
                return View(value);

            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateArticle(UpdateArticleDto updateArticleDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateArticleDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7079/api/Article", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ArticleList");
            }
            return View();
        }

    }
}
