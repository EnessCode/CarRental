using CarRental.Application.Features.CQRS.Results.CategoryResults;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.Features.CQRS.Handlers.CategoryHandlers
{
	public class GetCategoryQueryHandler(IRepository<Category> categoryRepository)
	{
		public async Task<List<GetCategoryQueryResult>> Handle()
		{
			var values = await categoryRepository.GetAllAsync();
			return values.Select(x => new GetCategoryQueryResult
			{
				Id = x.Id,
				Name = x.Name
			}).ToList();
		}
	}
}
