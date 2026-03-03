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
	public class GetAvgRentPriceForHourlyQueryHandler(IStatisticsRepository statisticsRepository) : IRequestHandler<GetAvgRentPriceForHourlyQuery, GetAvgRentPriceForHourlyQueryResult>
	{
		public async Task<GetAvgRentPriceForHourlyQueryResult> Handle(GetAvgRentPriceForHourlyQuery request, CancellationToken cancellationToken)
		{
			var value = await statisticsRepository.GetAvgRentPriceForHourly();
			return new GetAvgRentPriceForHourlyQueryResult
			{
				AvgRentPriceForHourly = value
			};
		}
	}
}