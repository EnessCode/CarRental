using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebUI.View_Components.DefaultViewComponents
{
	public class NavbarViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
