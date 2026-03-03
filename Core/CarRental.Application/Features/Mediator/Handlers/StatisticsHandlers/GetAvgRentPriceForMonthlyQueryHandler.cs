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
	public class GetAvgRentPriceForMonthlyQueryHandler(IStatisticsRepository statisticsRepository) : IRequestHandler<GetAvgRentPriceForMonthlyQuery, GetAvgRentPriceForMonthlyQueryResult>
	{
		public async Task<GetAvgRentPriceForMonthlyQueryResult> Handle(GetAvgRentPriceForMonthlyQuery request, CancellationToken cancellationToken)
		{
			var value = await statisticsRepository.GetAvgRentPriceForMonthly();
			return new GetAvgRentPriceForMonthlyQueryResult
			{
				AvgRentPriceForMonthly = value
			};
		}
	}
}