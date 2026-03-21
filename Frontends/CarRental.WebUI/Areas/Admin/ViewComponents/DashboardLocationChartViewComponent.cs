using CarRental.Dto;
using CarRental.Dto.DashboardDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarRental.WebUI.Areas.Admin.ViewComponents
{
	[ViewComponent(Name = "DashboardLocationChart")]
	public class DashboardLocationChartViewComponent(IHttpClientFactory httpClientFactory) : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = httpClientFactory.CreateClient("CarRentalApi");
			var responseMessage = await client.GetAsync("Statistics/GetCarCountByLocation");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var apiResponse = JsonConvert.DeserializeObject<ResultApiResponseDto<List<ResultCarCountByLocationDto>>>(jsonData);

				if (apiResponse != null && apiResponse.Success)
				{
					return View(apiResponse.Data);
				}
			}
			return View(new List<ResultCarCountByLocationDto>());
		}
	}
}