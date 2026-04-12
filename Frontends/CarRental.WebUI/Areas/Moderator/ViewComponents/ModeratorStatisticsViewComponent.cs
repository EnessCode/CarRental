using CarRental.Dto;
using CarRental.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace CarRental.WebUI.Areas.Moderator.ViewComponents
{
	[ViewComponent(Name = "ModeratorStatistics")]
	public class ModeratorStatisticsViewComponent(IHttpClientFactory httpClientFactory) : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var userId = ((ClaimsPrincipal)User).FindFirst(ClaimTypes.NameIdentifier)?.Value;
			var client = httpClientFactory.CreateClient("CarRentalApi");
			var statisticsDto = new ResultStatisticsDto();

			var responseBlog = await client.GetAsync("Statistics/GetBlogCountByAuthorId?id=" + userId); 
			if (responseBlog.IsSuccessStatusCode)
			{
				var jsonData = await responseBlog.Content.ReadAsStringAsync();
				var apiResponse = JsonConvert.DeserializeObject<ResultApiResponseDto<ResultStatisticsDto>>(jsonData);

				if (apiResponse != null && apiResponse.Success)
				{
					statisticsDto.blogCountByAuthorId = apiResponse.Data.blogCountByAuthorId;
				}
			}

			var responseComment = await client.GetAsync("Statistics/GetTotalCommentCountByAuthorId?id=" + userId); 
			if (responseComment.IsSuccessStatusCode)
			{
				var jsonData = await responseComment.Content.ReadAsStringAsync();
				var apiResponse = JsonConvert.DeserializeObject<ResultApiResponseDto<ResultStatisticsDto>>(jsonData);

				if (apiResponse != null && apiResponse.Success)
				{
					statisticsDto.totalCommentCountByAuthorId = apiResponse.Data.totalCommentCountByAuthorId;
				}
			}

			return View(statisticsDto);
		}
	}
}