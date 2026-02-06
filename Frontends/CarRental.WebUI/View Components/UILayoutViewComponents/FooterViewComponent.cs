using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebUI.View_Components.DefaultViewComponents
{
	public class FooterViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
