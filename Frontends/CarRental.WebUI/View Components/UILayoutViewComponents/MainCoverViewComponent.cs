using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebUI.View_Components.DefaultViewComponents
{
	public class MainCoverViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
