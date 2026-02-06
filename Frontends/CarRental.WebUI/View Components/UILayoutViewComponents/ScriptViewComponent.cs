using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebUI.View_Components.DefaultViewComponents
{
	public class ScriptViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
