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
	public class GetBrandNameByMaxCarCountQueryHandler(IStatisticsRepository statisticsRepository) : IRequestHandler<GetBrandNameByMaxCarCountQuery, GetBrandNameByMaxCarCountQueryResult>
	{
		public async Task<GetBrandNameByMaxCarCountQueryResult> Handle(GetBrandNameByMaxCarCountQuery request, CancellationToken cancellationToken)
		{
			var value = await statisticsRepository.GetBrandNameByMaxCarCount();
			return new GetBrandNameByMaxCarCountQueryResult
			{
				BrandNameByMaxCarCount = value
			};
		}
	}
}