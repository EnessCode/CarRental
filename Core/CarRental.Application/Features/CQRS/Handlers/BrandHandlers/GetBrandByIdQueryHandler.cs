using CarRental.Application.Common;
using CarRental.Application.Features.CQRS.Queries.BrandQueries;
using CarRental.Application.Features.CQRS.Results.BrandResults;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.Features.CQRS.Handlers.BrandHandlers
{
	public class GetBrandByIdQueryHandler(IRepository<Brand> brandRepository)
	{
		public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery query)
		{
			var value = await brandRepository.GetByIdAsync(query.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(Brand), query.Id);
			}

			return new GetBrandByIdQueryResult
			{
				Id = value.Id,
				Name = value.Name
			};
		}
	}
}