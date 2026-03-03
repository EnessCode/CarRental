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
	public class GetCarCountQueryHandler(IStatisticsRepository statisticsRepository) : IRequestHandler<GetCarCountQuery, GetCarCountQueryResult>
	{
		public async Task<GetCarCountQueryResult> Handle(GetCarCountQuery request, CancellationToken cancellationToken)
		{
			var value = await statisticsRepository.GetCarCount();
			return new GetCarCountQueryResult
			{
				CarCount = value
			};
		}
	}
}