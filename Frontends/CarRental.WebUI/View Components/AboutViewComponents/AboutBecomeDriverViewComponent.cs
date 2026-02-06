using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebUI.View_Components.AboutViewComponents
{
	public class AboutBecomeDriverViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
