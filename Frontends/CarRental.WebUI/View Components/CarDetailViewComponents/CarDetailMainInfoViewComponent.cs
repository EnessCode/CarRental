using CarRental.Dto;
using CarRental.Dto.CarDtos;
using CarRental.Dto.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarRental.WebUI.View_Components.CarDetailViewComponents
{
	public class CarDetailMainInfoViewComponent(IHttpClientFactory httpClientFactory) : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			var client = httpClientFactory.CreateClient("CarRentalApi");

			var responseMessage = await client.GetAsync("Cars/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();

				var apiResponse = JsonConvert.DeserializeObject<ResultApiResponseDto<ResultCarWithBrandDto>>(jsonData);
				if (apiResponse != null && apiResponse.Success)
				{
					var priceResponse = await client.GetAsync("CarPricings/GetCarPricingWithTimePeriodList");
					if (priceResponse.IsSuccessStatusCode)
					{
						var priceJson = await priceResponse.Content.ReadAsStringAsync();
						var priceResult = JsonConvert.DeserializeObject<ResultApiResponseDto<List<ResultCarPricingWithTimePeriodDto>>>(priceJson);
						if (priceResult?.Data != null)
						{
							var specificCarPrice = priceResult.Data.FirstOrDefault(x => x.CarID == id);
							ViewBag.CarPrice = specificCarPrice != null ? specificCarPrice.DailyAmount.ToString("N0") : "0";
						}
					}
					return View(apiResponse.Data);
				}
			}
			return View(new ResultCarWithBrandDto());
		}
	}
}