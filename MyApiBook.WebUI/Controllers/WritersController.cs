using Microsoft.AspNetCore.Mvc;
using MyApiBook.WebUI.Dtos;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MyApiBook.WebUI.Controllers
{
    public class WritersController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WritersController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> WriterList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7079/api/Writer");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultWriterDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateWriter()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateWriter(CreateAuthorDto createAuthorDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createAuthorDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var ResponseMessage = await client.PostAsync("https://localhost:7079/api/Writer", stringContent);
            if (ResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("WriterList");
            }
            return View();
        }

        public async Task<IActionResult> DeleteWriter(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7079/api/Writer?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("WriterList");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateWriter(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7079/api/Writer/GetWriter?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateAuthorDto>(jsonData);
                return View(value);

            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateWriter(UpdateAuthorDto updateAuthorDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateAuthorDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7079/api/Writer", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("WriterList");
            }
            return View();
        }
    }
}
