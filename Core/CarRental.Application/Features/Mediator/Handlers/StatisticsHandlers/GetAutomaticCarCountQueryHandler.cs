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
	public class GetAutomaticCarCountQueryHandler(IStatisticsRepository statisticsRepository) : IRequestHandler<GetAutomaticCarCountQuery, GetAutomaticCarCountQueryResult>
	{
		public async Task<GetAutomaticCarCountQueryResult> Handle(GetAutomaticCarCountQuery request, CancellationToken cancellationToken)
		{
			var value = await statisticsRepository.GetAutomaticCarCount();
			return new GetAutomaticCarCountQueryResult
			{
				AutomaticCarCount = value
			};
		}
	}
}
