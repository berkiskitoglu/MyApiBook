using Microsoft.AspNetCore.Mvc;
using MyApiBook.WebUI.Dtos;
using Newtonsoft.Json;
using System.Text;

namespace MyApiBook.WebUI.Controllers
{
    public class BooksController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BooksController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> BookList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7079/api/Book");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateBook()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookDto createBookDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var ResponseMessage = await client.PostAsync("https://localhost:7079/api/Book", stringContent);
            if (ResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("BookList");
            }
            return View();
        }

        public async Task<IActionResult> DeleteBook(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7079/api/Book?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("BookList");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateBook(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7079/api/Book/GetBook?id="+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateBookDto>(jsonData);
                return View(value);

            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBook(UpdateBookDto updateBookDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBookDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7079/api/Book", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("BookList");
            }
            return View();
        }
    }
}
