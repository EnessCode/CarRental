using CarRental.Dto;
using CarRental.Dto.BlogDtos;
using CarRental.Dto.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CarRental.WebUI.Controllers
{
	public class BlogController(IHttpClientFactory httpClientFactory) : Controller
	{
		public async Task<IActionResult> Index()
		{
			var client = httpClientFactory.CreateClient("CarRentalApi");

			var responseMessage = await client.GetAsync("Blogs/GetAllBlogsWithAuthor");
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
		public async Task<IActionResult> BlogDetail(int id)
		{
			var client = httpClientFactory.CreateClient("CarRentalApi");

			var responseMessage = await client.GetAsync("Blogs/GetBlogDetails/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();

				var apiResponse = JsonConvert.DeserializeObject<ResultApiResponseDto<ResultBlogDetailDto>>(jsonData);
				if (apiResponse != null && apiResponse.Success)
				{
					return View(apiResponse.Data);
				}
			}
			return View(new ResultBlogDetailDto());
		}

		[HttpGet]
		public async Task<IActionResult> BlogListByCategory(int id)
		{
			var client = httpClientFactory.CreateClient("CarRentalApi");

			var responseMessage = await client.GetAsync("Blogs/GetBlogsByCategoryId/" + id);
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

		[HttpPost]
		public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
		{
			var client = httpClientFactory.CreateClient("CarRentalApi");
			var jsonData = JsonConvert.SerializeObject(createCommentDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var responseMessage = await client.PostAsync("Comments", content);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("BlogDetail", "Blog", new { id = createCommentDto.BlogId });
			}
			return RedirectToAction("Index", "Default");
		}
	}
}
