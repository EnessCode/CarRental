using CarRental.Dto;
using CarRental.Dto.CarPricingDtos;
using CarRental.Dto.LocationDtos; 
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarRental.WebUI.Controllers
{
	public class CarPricingController(IHttpClientFactory httpClientFactory) : Controller
	{
		public async Task<IActionResult> Index()
		{
			var client = httpClientFactory.CreateClient("CarRentalApi");

			var locationResponse = await client.GetAsync("Locations");
			if (locationResponse.IsSuccessStatusCode)
			{
				var jsonLocationData = await locationResponse.Content.ReadAsStringAsync();
				var locationApiResponse = JsonConvert.DeserializeObject<ResultApiResponseDto<List<ResultLocationDto>>>(jsonLocationData);

				if (locationApiResponse != null && locationApiResponse.Success)
				{
					ViewBag.Locations = locationApiResponse.Data;
				}
			}

			var responseMessage = await client.GetAsync("CarPricings/GetCarPricingWithTimePeriodList");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();

				var apiResponse = JsonConvert.DeserializeObject<ResultApiResponseDto<List<ResultCarPricingWithTimePeriodDto>>>(jsonData);
				if (apiResponse != null && apiResponse.Success)
				{
					return View(apiResponse.Data);
				}
			}
			return View(new List<ResultCarPricingWithTimePeriodDto>());
		}
	}
}