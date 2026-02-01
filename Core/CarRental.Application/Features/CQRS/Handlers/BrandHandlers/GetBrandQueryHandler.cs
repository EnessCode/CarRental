using CarRental.Application.Features.CQRS.Results.BrandResults;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.Features.CQRS.Handlers.BrandHandlers
{
	public class GetBrandQueryHandler(IRepository<Brand> brandRepository)
	{
		public async Task<List<GetBrandQueryResult>> Handle()
		{
			var values = await brandRepository.GetAllAsync();
			return values.Select(x => new GetBrandQueryResult
			{
				Id = x.Id,
				Name = x.Name
			}).ToList();
		}
	}
}