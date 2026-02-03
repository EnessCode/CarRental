using CarRental.Application.Common;
using CarRental.Application.Features.Mediator.Queries.PricingQueries;
using CarRental.Application.Features.Mediator.Results.PricingResults;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.PricingHandlers
{
	public class GetPricingByIdQueryHandler(IRepository<Pricing> pricingRepository) : IRequestHandler<GetPricingByIdQuery, GetPricingByIdQueryResult>
	{
		public async Task<GetPricingByIdQueryResult> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
		{
			var value = await pricingRepository.GetByIdAsync(request.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(Pricing), request.Id);
			}

			return new GetPricingByIdQueryResult
			{
				Id = value.Id,
				Name = value.Name
			};
		}
	}
}