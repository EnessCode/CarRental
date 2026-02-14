using CarRental.Application.Features.Mediator.Queries.CarPricingQueries;
using CarRental.Application.Features.Mediator.Results.CarPricingResults;
using CarRental.Application.Features.Mediator.Results.LocationResults;
using CarRental.Application.Interfaces;
using CarRental.Application.Interfaces.CarPricingInterfaces;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.CarPricingHandlers
{
	public class GetCarPricingWithCarsQueryHandler(ICarPricingRepository carPricingRepository) : IRequestHandler<GetCarPricingWithCarsQuery, List<GetCarPricingWithCarsQueryResult>>
	{
		public async Task<List<GetCarPricingWithCarsQueryResult>> Handle(GetCarPricingWithCarsQuery request, CancellationToken cancellationToken)
		{
			var values = await carPricingRepository.GetCarPricingWithCars();
			return values.Select(x => new GetCarPricingWithCarsQueryResult
			{
				Id = x.Id,
				Brand = x.Car.Brand.Name,
				Model = x.Car.Model,
				CoverImageUrl = x.Car.CoverImageUrl,
				Amount = x.Amount
			}).ToList();
		}
	}
}
