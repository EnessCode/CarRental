using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebUI.Controllers
{
	public class AboutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
