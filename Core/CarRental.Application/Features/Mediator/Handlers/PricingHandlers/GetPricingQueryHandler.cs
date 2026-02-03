using CarRental.Application.Features.Mediator.Queries.PricingQueries;
using CarRental.Application.Features.Mediator.Results.PricingResults;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.PricingHandlers
{
	public class GetPricingQueryHandler(IRepository<Pricing> pricingRepository) : IRequestHandler<GetPricingQuery, List<GetPricingQueryResult>>
	{
		public async Task<List<GetPricingQueryResult>> Handle(GetPricingQuery request, CancellationToken cancellationToken)
		{
			var values = await pricingRepository.GetAllAsync();
			return values.Select(x => new GetPricingQueryResult
			{
				Id = x.Id,
				Name = x.Name
			}).ToList();
		}
	}
}