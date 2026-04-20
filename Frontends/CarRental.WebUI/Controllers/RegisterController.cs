using CarRental.Dto;
using CarRental.Dto.RegistersDto;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;

namespace CarRental.WebUI.Controllers
{
	public class RegisterController(IHttpClientFactory httpClientFactory) : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(RegisterDto registerDto)
		{
			var client = httpClientFactory.CreateClient("CarRentalApi");
			var content = new StringContent(JsonConvert.SerializeObject(registerDto), Encoding.UTF8, "application/json");
			var response = await client.PostAsync("Register", content);

			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Login");
			}

			var jsonData = await response.Content.ReadAsStringAsync();
			var apiResponse = JsonConvert.DeserializeObject<ResultApiResponseDto<NoContent>>(jsonData);

			if (apiResponse != null && !apiResponse.Success)
			{
				TempData["ErrorMessage"] = apiResponse.Message;
			}
			else
			{
				TempData["ErrorMessage"] = "Beklenmedik bir hata oluştu.";
			}

			return View(registerDto);
		}
	}
}
