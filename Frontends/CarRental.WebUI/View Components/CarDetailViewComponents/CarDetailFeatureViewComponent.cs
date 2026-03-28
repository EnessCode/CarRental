using CarRental.Dto;
using CarRental.Dto.CarDtos;
using CarRental.Dto.CarFeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarRental.WebUI.View_Components.CarDetailViewComponents
{
	public class CarDetailFeatureViewComponent(IHttpClientFactory httpClientFactory) : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			ViewBag.CarId = id;
			var client = httpClientFactory.CreateClient("CarRentalApi");

			var responseMessage = await client.GetAsync("CarFeatures/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();

				var apiResponse = JsonConvert.DeserializeObject<ResultApiResponseDto<List<ResultCarFeatureByCarIdDto>>>(jsonData);
				if (apiResponse != null && apiResponse.Success)
				{
					return View(apiResponse.Data);
				}
			}
			return View(new List<ResultCarFeatureByCarIdDto>());
		}
	}
}