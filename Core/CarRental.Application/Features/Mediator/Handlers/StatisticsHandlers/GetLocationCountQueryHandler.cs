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
	public class GetLocationCountQueryHandler(IStatisticsRepository statisticsRepository) : IRequestHandler<GetLocationCountQuery, GetLocationCountQueryResult>
	{
		public async Task<GetLocationCountQueryResult> Handle(GetLocationCountQuery request, CancellationToken cancellationToken)
		{
			var value = await statisticsRepository.GetLocationCount();
			return new GetLocationCountQueryResult
			{
				LocationCount = value
			};
		}
	}
}