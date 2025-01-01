using Microsoft.AspNetCore.Mvc;
using MyApiBook.WebUI.Dtos;
using Newtonsoft.Json;

namespace MyApiBook.WebUI.ViewComponents
{
	public class _AdventureBookListComponent : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _AdventureBookListComponent(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}


		public async Task<IViewComponentResult> InvokeAsync(int id = 5)
		{
			var client = _httpClientFactory.CreateClient();

			var responseMessage = await client.GetAsync("https://localhost:7079/api/Book/CategoryWithBooksAndAuthor?id=" + id);

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
