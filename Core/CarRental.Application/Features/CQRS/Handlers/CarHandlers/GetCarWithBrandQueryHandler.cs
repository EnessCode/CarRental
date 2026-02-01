using CarRental.Application.Features.CQRS.Results.CarResults;
using CarRental.Application.Interfaces;
using CarRental.Application.Interfaces.CarInterfaces;

namespace CarRental.Application.Features.CQRS.Handlers.CarHandlers
{
	public class GetCarWithBrandQueryHandler(ICarRepository carRepository)
	{
		public async Task<List<GetCarWithBrandQueryResult>> Handle()
		{
			var values = await carRepository.GetCarsWithBrand();
			return values.Select(x => new GetCarWithBrandQueryResult
			{
				Id = x.Id,
				BrandName = x.Brand.Name,
				BrandId = x.BrandId,
				Model = x.Model,
				CoverImageUrl = x.CoverImageUrl,
				Kilometer = x.Kilometer,
				Transmission = x.Transmission,
				Seat = x.Seat,
				Luggage = x.Luggage,
				Fuel = x.Fuel,
				BigImageUrl = x.BigImageUrl
			}).ToList();
		}
	}
}
