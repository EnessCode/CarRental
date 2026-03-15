using CarRental.Application.Features.Mediator.Queries.CarPricingQueries;
using CarRental.Application.Features.Mediator.Results.CarPricingResults;
using CarRental.Application.Interfaces.CarPricingInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.CarPricingHandlers
{
	public class GetCarPricingWithTimePeriodQueryHandler(ICarPricingRepository repository) : IRequestHandler<GetCarPricingWithTimePeriodQuery, List<GetCarPricingWithTimePeriodQueryResult>>
	{
		public async Task<List<GetCarPricingWithTimePeriodQueryResult>> Handle(GetCarPricingWithTimePeriodQuery request, CancellationToken cancellationToken)
		{
			return await repository.GetCarPricingWithTimePeriod();
		}
	}
}
