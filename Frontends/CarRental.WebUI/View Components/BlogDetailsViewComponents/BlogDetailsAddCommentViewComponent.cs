using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebUI.View_Components.BlogDetailsViewComponents
{
	public class BlogDetailsAddCommentViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
