using Microsoft.AspNetCore.Mvc;

namespace MyApiBook.WebUI.ViewComponents
{
	public class _FooterComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
