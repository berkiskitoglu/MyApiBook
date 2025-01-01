using Microsoft.AspNetCore.Mvc;
using MyApiBook.WebUI.Dtos;
using Newtonsoft.Json;
using System.Text;

namespace MyApiBook.WebUI.Controllers
{
    public class QuotationsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public QuotationsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> QuotationList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7079/api/Quotation");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultQuotationDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateQuotation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateQuotation(CreateQuotationDto createQuotationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createQuotationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var ResponseMessage = await client.PostAsync("https://localhost:7079/api/Quotation", stringContent);
            if (ResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("QuotationList");
            }
            return View();
        }

        public async Task<IActionResult> DeleteQuotation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7079/api/Quotation?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("QuotationList");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateQuotation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7079/api/Quotation/GetQuotation?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateQuotationDto>(jsonData);
                return View(value);

            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateQuotation(UpdateQuotationDto updateQuotationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateQuotationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7079/api/Quotation", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("QuotationList");
            }
            return View();
        }

    }
}
