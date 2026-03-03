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
	public class GetAuthorCountQueryHandler(IStatisticsRepository statisticsRepository) : IRequestHandler<GetAuthorCountQuery, GetAuthorCountQueryResult>
	{
		public async Task<GetAuthorCountQueryResult> Handle(GetAuthorCountQuery request, CancellationToken cancellationToken)
		{
			var value = await statisticsRepository.GetAuthorCount();
			return new GetAuthorCountQueryResult
			{
				AuthorCount = value
			};
		}
	}
}
