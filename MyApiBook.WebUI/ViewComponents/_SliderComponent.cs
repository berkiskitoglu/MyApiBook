using Microsoft.AspNetCore.Mvc;
using MyApiBook.WebUI.Dtos;
using Newtonsoft.Json;
using System.Net.Http;

namespace MyApiBook.WebUI.ViewComponents
{
	public class _SliderComponent : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _SliderComponent(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
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
	}
}
