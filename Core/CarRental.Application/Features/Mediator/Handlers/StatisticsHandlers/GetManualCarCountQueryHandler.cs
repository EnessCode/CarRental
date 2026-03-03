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
	public class GetManualCarCountQueryHandler(IStatisticsRepository statisticsRepository) : IRequestHandler<GetManualCarCountQuery, GetManualCarCountQueryResult>
	{
		public async Task<GetManualCarCountQueryResult> Handle(GetManualCarCountQuery request, CancellationToken cancellationToken)
		{
			var value = await statisticsRepository.GetManualCarCount();
			return new GetManualCarCountQueryResult
			{
				ManualCarCount = value
			};
		}
	}
}