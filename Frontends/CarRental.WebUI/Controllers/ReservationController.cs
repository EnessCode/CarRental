using CarRental.Dto;
using CarRental.Dto.CarDtos;
using CarRental.Dto.LocationDtos;
using CarRental.Dto.ReservationDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CarRental.WebUI.Controllers
{
	[Authorize]
	public class ReservationController(IHttpClientFactory httpClientFactory) : Controller
	{
		[HttpGet]
		public async Task<IActionResult> Index(int carId, int locationId, DateOnly pickUpDate, DateOnly dropOffDate, TimeOnly pickUpTime, TimeOnly dropOffTime)
		{
			var client = httpClientFactory.CreateClient("CarRentalApi");

			var responseMessage = await client.GetAsync("Locations");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<ResultApiResponseDto<List<ResultLocationDto>>>(jsonData);

				ViewBag.locationList = values.Data.Select(x => new SelectListItem
				{
					Text = x.Name,
					Value = x.Id.ToString()
				}).ToList();

				var locationName = values.Data.FirstOrDefault(x => x.Id == locationId)?.Name;
				ViewBag.locationName = locationName;
			}

			var carResponse = await client.GetAsync("Cars/GetCarWithBrandById/" + carId);
			if (carResponse.IsSuccessStatusCode)
			{
				var carData = await carResponse.Content.ReadAsStringAsync();
				var carDetail = JsonConvert.DeserializeObject<ResultApiResponseDto<ResultCarWithBrandDto>>(carData);
				ViewBag.carModel = carDetail.Data.Model;
				ViewBag.carBrand = carDetail.Data.BrandName; 
				ViewBag.carImage = carDetail.Data.CoverImageUrl;
			}

			ViewBag.carId = carId;
			ViewBag.locationId = locationId;
			ViewBag.pickUpDate = pickUpDate;
			ViewBag.dropOffDate = dropOffDate;
			ViewBag.pickUpTime = pickUpTime;
			ViewBag.dropOffTime = dropOffTime;

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(CreateReservationDto createReservationDto)
		{
			var client = httpClientFactory.CreateClient("CarRentalApi");
			var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == System.Security.Claims.ClaimTypes.NameIdentifier);
			
			if (userIdClaim != null)
			{
				createReservationDto.AppUserId = int.Parse(userIdClaim.Value);
			}

			var jsonData = JsonConvert.SerializeObject(createReservationDto);
			StringContent stringContent = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("Reservations", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Default");
			}
			return View();
		}
	}
}
