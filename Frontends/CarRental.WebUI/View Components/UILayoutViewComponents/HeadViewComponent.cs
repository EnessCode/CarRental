using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebUI.View_Components.DefaultViewComponents
{
	public class HeadViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
