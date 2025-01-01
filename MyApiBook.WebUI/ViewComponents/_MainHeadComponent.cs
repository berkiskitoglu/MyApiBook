using Microsoft.AspNetCore.Mvc;

namespace MyApiBook.WebUI.ViewComponents
{
	public class _MainHeadComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
