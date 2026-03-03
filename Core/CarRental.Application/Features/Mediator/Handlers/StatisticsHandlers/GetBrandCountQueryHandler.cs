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
	public class GetBrandCountQueryHandler(IStatisticsRepository statisticsRepository) : IRequestHandler<GetBrandCountQuery, GetBrandCountQueryResult>
	{
		public async Task<GetBrandCountQueryResult> Handle(GetBrandCountQuery request, CancellationToken cancellationToken)
		{
			var value = await statisticsRepository.GetBrandCount();
			return new GetBrandCountQueryResult
			{
				BrandCount = value
			};
		}
	}
}