using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebUI.View_Components.BlogDetailsViewComponents
{
	public class BlogDetailsAddCommentViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke(int id)
		{
			ViewBag.blogid = id;
			return View();
		}
	}
}
