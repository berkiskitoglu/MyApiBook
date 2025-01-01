using Microsoft.AspNetCore.Mvc;

namespace MyApiBook.WebUI.ViewComponents
{
	public class _DefaultJavaScriptsComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
