using CarRental.Application.Features.Mediator.Queries.RentACarQueries;
using CarRental.Application.Features.Mediator.Results.RentACarResults;
using CarRental.Application.Interfaces.RentACarInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.RentACarHandlers
{
	public class GetRentACarQueryHandler(IRentACarRepository rentACarRepository) : IRequestHandler<GetRentACarQuery, List<GetRentACarQueryResult>>
	{
		public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
		{
			var values = await rentACarRepository.GetByFilterAsync(x => x.LocationId == request.LocationId && x.Available == request.Available);
			return values.Select(x => new GetRentACarQueryResult
			{
				CarId = x.CarId,
				Brand = x.Car.Brand.Name,
				Model = x.Car.Model,
				CoverImageUrl = x.Car.CoverImageUrl,
				Transmission = x.Car.Transmission,
				Fuel = x.Car.Fuel,
				Kilometer = x.Car.Kilometer,
				Seat = x.Car.Seat,
				Luggage = x.Car.Luggage,
				Amount = x.Car.CarPricings.FirstOrDefault(y => y.PricingId == 3)?.Amount ?? 0
			}).ToList();
		}
	}
}
