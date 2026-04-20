using CarRental.Dto.LoginDtos;
using CarRental.WebUI.Models;
using CarRental.Dto; 
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json; 
using System.IdentityModel.Tokens.Jwt; 
using System.Security.Claims;
using System.Text;

namespace CarRental.WebUI.Controllers
{
	public class LoginController(IHttpClientFactory httpClientFactory) : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(LoginDto loginDto)
		{
			var client = httpClientFactory.CreateClient("CarRentalApi");
			var content = new StringContent(JsonConvert.SerializeObject(loginDto), Encoding.UTF8, "application/json");

			var response = await client.PostAsync("Login", content);

			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();

				var apiResponse = JsonConvert.DeserializeObject<ResultApiResponseDto<JwtResponseModel>>(jsonData);

				if (apiResponse != null && apiResponse.Success && apiResponse.Data != null)
				{
					var tokenModel = apiResponse.Data;
					var handler = new JwtSecurityTokenHandler();
					var token = handler.ReadJwtToken(tokenModel.Token) as JwtSecurityToken;

					if (token != null)
					{
						var claims = token.Claims.ToList();
						claims.Add(new Claim("accessToken", tokenModel.Token));

						var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
						var authProperties = new AuthenticationProperties
						{
							ExpiresUtc = tokenModel.ExpireDate,
							IsPersistent = true
						};

						await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

						var role = claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;

						if (role == "Admin")
							return RedirectToAction("Index", "Dashboard", new { area = "Admin" });

						if (role == "Moderator")
							return RedirectToAction("Index", "Dashboard", new { area = "Moderator" });

						return RedirectToAction("Index", "Default");
					}
				}
			}

			ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı!");
			return View();
		}

		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Index", "Login");
		}
	}
}