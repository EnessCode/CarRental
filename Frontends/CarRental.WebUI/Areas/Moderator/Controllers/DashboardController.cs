using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebUI.Areas.Moderator.Controllers
{
	[Area("Moderator")]
	public class DashboardController : BaseModeratorController
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
