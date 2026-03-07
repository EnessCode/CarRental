using CarRental.Dto;
using CarRental.Dto.RentACarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarRental.WebUI.Controllers
{
	public class RentACarFilterController(IHttpClientFactory _httpClientFactory) : Controller
	{
		public async Task<IActionResult> Index(int locationId, DateOnly pickUpDate, TimeOnly pickUpTime, DateOnly dropOffDate, TimeOnly dropOffTime)
		{
			var client = _httpClientFactory.CreateClient("CarRentalApi");
			var responseMessage = await client.GetAsync("RentACars?LocationId=" + locationId + "&Available=true");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<ResultApiResponseDto<List<ResultRentACarDto>>>(jsonData);
				return View(values.Data);
			}
			return View(new List<ResultRentACarDto>());
		}
	}
}
