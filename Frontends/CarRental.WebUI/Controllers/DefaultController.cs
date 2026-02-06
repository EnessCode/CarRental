using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebUI.Controllers
{
	public class DefaultController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
