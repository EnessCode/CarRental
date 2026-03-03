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
	public class GetBlogCountQueryHandler(IStatisticsRepository statisticsRepository) : IRequestHandler<GetBlogCountQuery, GetBlogCountQueryResult>
	{
		public async Task<GetBlogCountQueryResult> Handle(GetBlogCountQuery request, CancellationToken cancellationToken)
		{
			var value = await statisticsRepository.GetBlogCount();
			return new GetBlogCountQueryResult
			{
				BlogCount = value
			};
		}
	}
}