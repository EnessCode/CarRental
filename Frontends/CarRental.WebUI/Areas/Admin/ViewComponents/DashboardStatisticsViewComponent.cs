using CarRental.Dto;
using CarRental.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarRental.WebUI.Areas.Admin.ViewComponents
{
	[ViewComponent(Name = "DashboardStatistics")]

	public class DashboardStatisticsViewComponent(IHttpClientFactory httpClientFactory) : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = httpClientFactory.CreateClient("CarRentalApi");

			var responseMessage1 = await client.GetAsync("Statistics/GetCarCount");
			if (responseMessage1.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage1.Content.ReadAsStringAsync();
				var apiResponse = JsonConvert.DeserializeObject<ResultApiResponseDto<ResultStatisticsDto>>(jsonData);
				ViewBag.carCount = apiResponse.Data.carCount;
			}

			var responseMessage2 = await client.GetAsync("Statistics/GetLocationCount");
			if (responseMessage2.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage2.Content.ReadAsStringAsync();
				var apiResponse = JsonConvert.DeserializeObject<ResultApiResponseDto<ResultStatisticsDto>>(jsonData);
				ViewBag.locationCount = apiResponse.Data.locationCount;
			}

			var responseMessage3 = await client.GetAsync("Statistics/GetBrandCount");
			if (responseMessage3.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage3.Content.ReadAsStringAsync();
				var apiResponse = JsonConvert.DeserializeObject<ResultApiResponseDto<ResultStatisticsDto>>(jsonData);
				ViewBag.brandCount = apiResponse.Data.brandCount;
			}

			var responseMessage4 = await client.GetAsync("Statistics/GetBlogCount");
			if (responseMessage4.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage4.Content.ReadAsStringAsync();
				var apiResponse = JsonConvert.DeserializeObject<ResultApiResponseDto<ResultStatisticsDto>>(jsonData);
				ViewBag.blogCount = apiResponse.Data.blogCount;
			}

			return View();
		}
	}
}
