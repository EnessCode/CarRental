using CarRental.Dto;
using CarRental.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace CarRental.WebUI.Areas.Moderator.Controllers
{
	[Area("Moderator")]
	public class BlogController(IHttpClientFactory httpClientFactory) : BaseModeratorController
	{
		private string GetUserId() => User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

		public async Task<IActionResult> Index()
		{
			var client = httpClientFactory.CreateClient("CarRentalApi");
			var responseMessage = await client.GetAsync("Blogs/GetBlogsByAuthorId/" + GetUserId());

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var apiResponse = JsonConvert.DeserializeObject<ResultApiResponseDto<List<ResultAllBlogsWithAuthorDto>>>(jsonData);
				if (apiResponse != null && apiResponse.Success)
				{
					return View(apiResponse.Data);
				}
			}
			return View(new List<ResultAllBlogsWithAuthorDto>());
		}

		[HttpGet]
		public IActionResult CreateBlog()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateBlog(CreateBlogDto createBlogDto)
		{
			createBlogDto.AppUserId = int.Parse(GetUserId());
			createBlogDto.CreatedAt = DateTime.Now;

			var client = httpClientFactory.CreateClient("CarRentalApi");
			var jsonData = JsonConvert.SerializeObject(createBlogDto);
			var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("Blogs", stringContent);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View(createBlogDto);
		}

		public async Task<IActionResult> DeleteBlog(int id)
		{
			var client = httpClientFactory.CreateClient("CarRentalApi");
			await client.DeleteAsync("Blogs/" + id);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> UpdateBlog(int id)
		{
			var client = httpClientFactory.CreateClient("CarRentalApi");
			var responseMessage = await client.GetAsync("Blogs/" + id);

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var apiResponse = JsonConvert.DeserializeObject<ResultApiResponseDto<UpdateBlogDto>>(jsonData);
				return View(apiResponse.Data);
			}
			return RedirectToAction("Index");
		}

		[HttpPost]
		public async Task<IActionResult> UpdateBlog(UpdateBlogDto updateBlogDto)
		{
			updateBlogDto.AppUserId = int.Parse(GetUserId()); 

			var client = httpClientFactory.CreateClient("CarRentalApi");
			var jsonData = JsonConvert.SerializeObject(updateBlogDto);
			var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("Blogs", stringContent);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View(updateBlogDto);
		}
	}
}