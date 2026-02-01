using CarRental.Application.Features.CQRS.Results.CarResults;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.Features.CQRS.Handlers.CarHandlers
{
	public class GetCarQueryHandler(IRepository<Car> carRepository)
	{
		public async Task<List<GetCarQueryResult>> Handle()
		{
			var values = await carRepository.GetAllAsync();
			return values.Select(x => new GetCarQueryResult
			{
				Id = x.Id,
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