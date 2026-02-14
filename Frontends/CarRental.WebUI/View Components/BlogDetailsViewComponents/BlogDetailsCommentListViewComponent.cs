using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebUI.View_Components.BlogDetailsViewComponents
{
	public class BlogDetailsCommentListViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
