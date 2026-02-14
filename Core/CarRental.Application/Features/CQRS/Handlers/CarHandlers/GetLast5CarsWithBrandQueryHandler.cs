using CarRental.Application.Features.CQRS.Results.CarResults;
using CarRental.Application.Interfaces.CarInterfaces;


namespace CarRental.Application.Features.CQRS.Handlers.CarHandlers
{
	public class GetLast5CarsWithBrandQueryHandler(ICarRepository carRepository)
	{
		public async Task<List<GetLast5CarsWithBrandQueryResult>> Handle()
		{
			var values = await carRepository.GetLast5CarsWithBrand();
			return values.Select(x => new GetLast5CarsWithBrandQueryResult
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
