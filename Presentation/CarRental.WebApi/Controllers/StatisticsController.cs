using CarRental.Application.Common;
using CarRental.Application.Features.Mediator.Queries.BlogQueries;
using CarRental.Application.Features.Mediator.Queries.StatisticsQueries;
using CarRental.Application.Features.Mediator.Results.BlogResults;
using CarRental.Application.Features.Mediator.Results.StatisticsResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class StatisticsController(IMediator mediator) : ControllerBase
	{
		[Authorize(Roles = "Admin")]
		[HttpGet("GetCarCount")]
		public async Task<IActionResult> GetCarCount()
		{
			var result = await mediator.Send(new GetCarCountQuery());
			return Ok(ApiResponse<GetCarCountQueryResult>.SuccessResponse(result, "Toplam araç sayısı başarıyla getirildi."));
		}

		[Authorize(Roles = "Admin")]
		[HttpGet("GetLocationCount")]
		public async Task<IActionResult> GetLocationCount()
		{
			var result = await mediator.Send(new GetLocationCountQuery());
			return Ok(ApiResponse<GetLocationCountQueryResult>.SuccessResponse(result, "Lokasyon sayısı başarıyla getirildi."));
		}

		[Authorize(Roles = "Admin")]
		[HttpGet("GetAuthorCount")]
		public async Task<IActionResult> GetAuthorCount()
		{
			var result = await mediator.Send(new GetAuthorCountQuery());
			return Ok(ApiResponse<GetAuthorCountQueryResult>.SuccessResponse(result, "Yazar sayısı başarıyla getirildi."));
		}

		[Authorize(Roles = "Admin,Moderator")]
		[HttpGet("GetBlogCount")]
		public async Task<IActionResult> GetBlogCount()
		{
			var result = await mediator.Send(new GetBlogCountQuery());
			return Ok(ApiResponse<GetBlogCountQueryResult>.SuccessResponse(result, "Blog sayısı başarıyla getirildi."));
		}

		[Authorize(Roles = "Admin")]
		[HttpGet("GetBrandCount")]
		public async Task<IActionResult> GetBrandCount()
		{
			var result = await mediator.Send(new GetBrandCountQuery());
			return Ok(ApiResponse<GetBrandCountQueryResult>.SuccessResponse(result, "Marka sayısı başarıyla getirildi."));
		}

		[Authorize(Roles = "Admin")]
		[HttpGet("GetAvgRentPriceForDaily")]
		public async Task<IActionResult> GetAvgRentPriceForDaily()
		{
			var result = await mediator.Send(new GetAvgRentPriceForDailyQuery());
			return Ok(ApiResponse<GetAvgRentPriceForDailyQueryResult>.SuccessResponse(result, "Günlük ortalama araç kiralama fiyatı başarıyla getirildi."));
		}

		[Authorize(Roles = "Admin")]
		[HttpGet("GetAvgRentPriceForWeekly")]
		public async Task<IActionResult> GetAvgRentPriceForWeekly()
		{
			var result = await mediator.Send(new GetAvgRentPriceForWeeklyQuery());
			return Ok(ApiResponse<GetAvgRentPriceForWeeklyQueryResult>.SuccessResponse(result, "Haftalık ortalama araç kiralama fiyatı başarıyla getirildi."));
		}

		[Authorize(Roles = "Admin")]
		[HttpGet("GetAvgRentPriceForMonthly")]
		public async Task<IActionResult> GetAvgRentPriceForMonthly()
		{
			var result = await mediator.Send(new GetAvgRentPriceForMonthlyQuery());
			return Ok(ApiResponse<GetAvgRentPriceForMonthlyQueryResult>.SuccessResponse(result, "Aylık ortalama araç kiralama fiyatı başarıyla getirildi."));
		}

		[Authorize(Roles = "Admin")]
		[HttpGet("GetAutomaticCarCount")]
		public async Task<IActionResult> GetAutomaticCarCount()
		{
			var result = await mediator.Send(new GetAutomaticCarCountQuery());
			return Ok(ApiResponse<GetAutomaticCarCountQueryResult>.SuccessResponse(result, "Otomatik vites araç sayısı başarıyla getirildi."));
		}

		[Authorize(Roles = "Admin")]
		[HttpGet("GetManualCarCount")]
		public async Task<IActionResult> GetManualCarCount()
		{
			var result = await mediator.Send(new GetManualCarCountQuery());
			return Ok(ApiResponse<GetManualCarCountQueryResult>.SuccessResponse(result, "Manuel vites araç sayısı başarıyla getirildi."));
		}

		[Authorize(Roles = "Admin")]
		[HttpGet("GetCarCountByFuelGasoline")]
		public async Task<IActionResult> GetCarCountByFuelGasoline()
		{
			var result = await mediator.Send(new GetCarCountByFuelGasolineQuery());
			return Ok(ApiResponse<GetCarCountByFuelGasolineQueryResult>.SuccessResponse(result, "Benzinli araç sayısı başarıyla getirildi."));
		}

		[Authorize(Roles = "Admin")]
		[HttpGet("GetCarCountByFuelDiesel")]
		public async Task<IActionResult> GetCarCountByFuelDiesel()
		{
			var result = await mediator.Send(new GetCarCountByFuelDieselQuery());
			return Ok(ApiResponse<GetCarCountByFuelDieselQueryResult>.SuccessResponse(result, "Dizel araç sayısı başarıyla getirildi."));
		}

		[Authorize(Roles = "Admin")]
		[HttpGet("GetCarCountByFuelElectric")]
		public async Task<IActionResult> GetCarCountByFuelElectric()
		{
			var result = await mediator.Send(new GetCarCountByFuelElectricQuery());
			return Ok(ApiResponse<GetCarCountByFuelElectricQueryResult>.SuccessResponse(result, "Elektrikli araç sayısı başarıyla getirildi."));
		}

		[Authorize(Roles = "Admin")]
		[HttpGet("GetBrandNameByMaxCarCount")]
		public async Task<IActionResult> GetBrandNameByMaxCarCount()
		{
			var result = await mediator.Send(new GetBrandNameByMaxCarCountQuery());
			return Ok(ApiResponse<GetBrandNameByMaxCarCountQueryResult>.SuccessResponse(result, "En çok araca sahip marka başarıyla getirildi."));
		}

		[Authorize(Roles = "Admin")]
		[HttpGet("GetCarBrandAndModelByMaxRentPrice")]
		public async Task<IActionResult> GetCarBrandAndModelByMaxRentPrice()
		{
			var result = await mediator.Send(new GetCarBrandAndModelByMaxRentPriceQuery());
			return Ok(ApiResponse<GetCarBrandAndModelByMaxRentPriceQueryResult>.SuccessResponse(result, "En yüksek fiyatlı kiralık araç başarıyla getirildi."));
		}

		[Authorize(Roles = "Admin")]
		[HttpGet("GetCarBrandAndModelByMinRentPrice")]
		public async Task<IActionResult> GetCarBrandAndModelByMinRentPrice()
		{
			var result = await mediator.Send(new GetCarBrandAndModelByMinRentPriceQuery());
			return Ok(ApiResponse<GetCarBrandAndModelByMinRentPriceQueryResult>.SuccessResponse(result, "En düşük fiyatlı kiralık araç başarıyla getirildi."));
		}

		[Authorize(Roles = "Admin")]
		[HttpGet("GetBrandDistribution")]
		public async Task<IActionResult> GetBrandDistribution()
		{
			var result = await mediator.Send(new GetBrandDistributionQuery());
			return Ok(ApiResponse<List<GetBrandDistributionQueryResult>>.SuccessResponse(result, "Marka dağılımı başarıyla getirildi."));
		}

		[Authorize(Roles = "Admin")]
		[HttpGet("GetCarCountByLocation")]
		public async Task<IActionResult> GetCarCountByLocation()
		{
			var result = await mediator.Send(new GetCarCountByLocationQuery());
			return Ok(ApiResponse<List<GetCarCountByLocationQueryResult>>.SuccessResponse(result, "Lokasyon bazlı araç sayıları getirildi."));
		}

		[Authorize(Roles = "Admin")]
		[HttpGet("GetLast5BlogsWithAuthor")]
		public async Task<IActionResult> GetLast5BlogsWithAuthor()
		{
			var result = await mediator.Send(new GetLast5BlogsWithAuthorQuery());
			return Ok(ApiResponse<List<GetLast5BlogsWithAuthorQueryResult>>.SuccessResponse(result));
		}

		[Authorize(Roles = "Admin,Moderator")]
		[HttpGet("GetLast5BlogsByAuthorId")]
		public async Task<IActionResult> GetLast5BlogsByAuthorId(int id)
		{
			var result = await mediator.Send(new GetLast5BlogsWithAuthorQuery(id));
			return Ok(ApiResponse<List<GetLast5BlogsWithAuthorQueryResult>>.SuccessResponse(result));
		}

		[Authorize(Roles = "Admin,Moderator")]
		[HttpGet("GetBlogCountByAuthorId")]
		public async Task<IActionResult> GetBlogCountByAuthorId(int id)
		{
			var result = await mediator.Send(new GetBlogCountByAuthorIdQuery(id));
			return Ok(ApiResponse<GetBlogCountByAuthorIdQueryResult>.SuccessResponse(result, "Moderatöre ait blog sayısı getirildi."));
		}

		[Authorize(Roles = "Admin,Moderator")]
		[HttpGet("GetTotalCommentCountByAuthorId")]
		public async Task<IActionResult> GetTotalCommentCountByAuthorId(int id)
		{
			var result = await mediator.Send(new GetTotalCommentCountByAuthorIdQuery(id));
			return Ok(ApiResponse<GetTotalCommentCountByAuthorIdQueryResult>.SuccessResponse(result, "Moderatöre ait toplam yorum sayısı getirildi."));
		}
	}
}