using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebUI.Areas.Moderator.Controllers
{
	[Area("Moderator")]
	[Authorize(Roles = "Admin,Moderator")] 
	public class BaseModeratorController : Controller
	{
	}
}
