using CarRental.Dto;
using CarRental.Dto.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarRental.WebUI.View_Components.BlogDetailsViewComponents
{
	public class BlogDetailsCommentListViewComponent(IHttpClientFactory httpClientFactory) : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			var client = httpClientFactory.CreateClient("CarRentalApi");

			var responseMessage = await client.GetAsync("Comments/CommentListByBlog/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var apiResponse = JsonConvert.DeserializeObject<ResultApiResponseDto<List<ResultCommentDto>>>(jsonData);

				if (apiResponse != null && apiResponse.Success)
				{
					return View(apiResponse.Data);
				}
			}
			return View(new List<ResultCommentDto>());
		}
	}
}
