using CarRental.Application.Features.Mediator.Queries.StatisticsQueries;
using CarRental.Application.Features.Mediator.Results.StatisticsResults;
using CarRental.Application.Interfaces.CarInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.StatisticsHandlers
{
	public class GetBrandDistributionQueryHandler(ICarRepository repository) : IRequestHandler<GetBrandDistributionQuery, List<GetBrandDistributionQueryResult>>
	{
		public async Task<List<GetBrandDistributionQueryResult>> Handle(GetBrandDistributionQuery request, CancellationToken cancellationToken)
		{
			var values = await repository.GetCarsWithBrand();
			return values.GroupBy(x => x.Brand.Name)
						 .Select(y => new GetBrandDistributionQueryResult
						 {
							 BrandName = y.Key,
							 CarCount = y.Count()
						 }).ToList();
		}
	}
}
