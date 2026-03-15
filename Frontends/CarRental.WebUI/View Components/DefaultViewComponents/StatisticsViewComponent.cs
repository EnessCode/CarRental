using CarRental.Dto;
using CarRental.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarRental.WebUI.View_Components.DefaultViewComponents
{
	public class StatisticsViewComponent(IHttpClientFactory httpClientFactory) : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = httpClientFactory.CreateClient("CarRentalApi");
			var stats = new ResultStatisticsDto();

			var resCar = await client.GetAsync("Statistics/GetCarCount");
			if (resCar.IsSuccessStatusCode)
			{
				var data = await resCar.Content.ReadAsStringAsync();
				stats.carCount = JsonConvert.DeserializeObject<ResultApiResponseDto<ResultStatisticsDto>>(data).Data.carCount;
			}

			var resLoc = await client.GetAsync("Statistics/GetLocationCount");
			if (resLoc.IsSuccessStatusCode)
			{
				var data = await resLoc.Content.ReadAsStringAsync();
				stats.locationCount = JsonConvert.DeserializeObject<ResultApiResponseDto<ResultStatisticsDto>>(data).Data.locationCount;
			}

			var resBrand = await client.GetAsync("Statistics/GetBrandCount");
			if (resBrand.IsSuccessStatusCode)
			{
				var data = await resBrand.Content.ReadAsStringAsync();
				stats.brandCount = JsonConvert.DeserializeObject<ResultApiResponseDto<ResultStatisticsDto>>(data).Data.brandCount;
			}

			var resAvg = await client.GetAsync("Statistics/GetAvgRentPriceForDaily");
			if (resAvg.IsSuccessStatusCode)
			{
				var data = await resAvg.Content.ReadAsStringAsync();
				stats.avgRentPriceForDaily = JsonConvert.DeserializeObject<ResultApiResponseDto<ResultStatisticsDto>>(data).Data.avgRentPriceForDaily;
			}

			return View(stats);
		}
	}
}
