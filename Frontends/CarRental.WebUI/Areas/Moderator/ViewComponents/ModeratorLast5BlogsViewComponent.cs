using CarRental.Dto;
using CarRental.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace CarRental.WebUI.Areas.Moderator.ViewComponents
{
	[ViewComponent(Name = "ModeratorLast5Blogs")]
	public class ModeratorLast5BlogsViewComponent(IHttpClientFactory httpClientFactory) : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var userId = ((ClaimsPrincipal)User).FindFirst(ClaimTypes.NameIdentifier)?.Value;
			var client = httpClientFactory.CreateClient("CarRentalApi");

			var responseMessage = await client.GetAsync("Statistics/GetLast5BlogsByAuthorId?id=" + userId);

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var apiResponse = JsonConvert.DeserializeObject<ResultApiResponseDto<List<ResultLast5BlogsWithAuthorDto>>>(jsonData);

				if (apiResponse != null && apiResponse.Success)
				{
					return View(apiResponse.Data);
				}
			}

			return View(new List<ResultLast5BlogsWithAuthorDto>());
		}
	}
}