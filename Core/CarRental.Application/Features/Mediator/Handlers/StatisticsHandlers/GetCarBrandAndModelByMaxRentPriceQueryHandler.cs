using CarRental.Application.Features.Mediator.Queries.StatisticsQueries;
using CarRental.Application.Features.Mediator.Results.StatisticsResults;
using CarRental.Application.Interfaces.StatisticsInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.StatisticsHandlers
{
	public class GetCarBrandAndModelByMaxRentPriceQueryHandler(IStatisticsRepository statisticsRepository) : IRequestHandler<GetCarBrandAndModelByMaxRentPriceQuery, GetCarBrandAndModelByMaxRentPriceQueryResult>
	{
		public async Task<GetCarBrandAndModelByMaxRentPriceQueryResult> Handle(GetCarBrandAndModelByMaxRentPriceQuery request, CancellationToken cancellationToken)
		{
			var value = await statisticsRepository.GetCarBrandAndModelByMaxRentPrice();
			return new GetCarBrandAndModelByMaxRentPriceQueryResult
			{
				CarBrandAndModelByMaxRentPrice = value
			};
		}
	}
}