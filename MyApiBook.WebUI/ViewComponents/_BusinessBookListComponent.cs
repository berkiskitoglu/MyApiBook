using Microsoft.AspNetCore.Mvc;
using MyApiBook.WebUI.Dtos;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace MyApiBook.WebUI.ViewComponents
{
	public class _BusinessBookListComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BusinessBookListComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

		public async Task<IViewComponentResult> InvokeAsync(int id = 2)
		{
			var client = _httpClientFactory.CreateClient();
			
			var responseMessage = await client.GetAsync("https://localhost:7079/api/Book/CategoryWithBooksAndAuthor?id="+id);

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCategoryWithBookAndAuthor>>(jsonData);
				return View(values);
			}
			return View();
		}

	}

}
