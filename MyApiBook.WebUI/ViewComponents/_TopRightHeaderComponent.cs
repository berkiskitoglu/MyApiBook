using Microsoft.AspNetCore.Mvc;

namespace MyApiBook.WebUI.ViewComponents
{
	public class _TopRightHeaderComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
