using Microsoft.AspNetCore.Mvc;

namespace MyApiBook.WebUI.ViewComponents
{
	public class _SubscribeComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
