using CarRental.Application.Common;
using CarRental.Application.Features.CQRS.Queries.CarQueries;
using CarRental.Application.Features.CQRS.Results.CarResults;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.Features.CQRS.Handlers.CarHandlers
{
	public class GetCarByIdQueryHandler(IRepository<Car> carRepository)
	{
		public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
		{
			var value = await carRepository.GetByIdAsync(query.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(Car), query.Id);
			}

			return new GetCarByIdQueryResult
			{
				Id = value.Id,
				BrandId = value.BrandId,
				Model = value.Model,
				CoverImageUrl = value.CoverImageUrl,
				Kilometer = value.Kilometer,
				Transmission = value.Transmission,
				Seat = value.Seat,
				Luggage = value.Luggage,
				Fuel = value.Fuel,
				BigImageUrl = value.BigImageUrl
			};
		}
	}
}