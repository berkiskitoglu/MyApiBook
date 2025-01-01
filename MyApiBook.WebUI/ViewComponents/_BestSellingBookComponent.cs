using Microsoft.AspNetCore.Mvc;
using MyApiBook.WebUI.Dtos;
using Newtonsoft.Json;

namespace MyApiBook.WebUI.ViewComponents
{
	public class _BestSellingBookComponent : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _BestSellingBookComponent(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7079/api/Book/BookWithAuthor");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<BookWithAuthorListDto>>(jsonData);
				return View(values);
			}
			
			return View();

		}
	}
}
