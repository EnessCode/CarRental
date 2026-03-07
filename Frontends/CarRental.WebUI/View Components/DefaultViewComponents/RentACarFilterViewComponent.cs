using CarRental.Dto;
using CarRental.Dto.BannerDtos;
using CarRental.Dto.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarRental.WebUI.View_Components.DefaultViewComponents
{
	public class RentACarFilterViewComponent(IHttpClientFactory httpClientFactory) : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = httpClientFactory.CreateClient("CarRentalApi");

			var responseMessage = await client.GetAsync("Locations");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();

				var apiResponse = JsonConvert.DeserializeObject<ResultApiResponseDto<List<ResultLocationDto>>>(jsonData);
				if (apiResponse != null && apiResponse.Success)
				{
					return View(apiResponse.Data);
				}
			}
			return View(new List<ResultLocationDto>());
		}
	}
}
