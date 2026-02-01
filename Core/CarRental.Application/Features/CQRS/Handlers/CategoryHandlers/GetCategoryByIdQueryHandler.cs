using CarRental.Application.Common;
using CarRental.Application.Features.CQRS.Queries.CategoryQueries;
using CarRental.Application.Features.CQRS.Results.CategoryResults;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.Features.CQRS.Handlers.CategoryHandlers
{
	public class GetCategoryByIdQueryHandler(IRepository<Category> categoryRepository)
	{
		public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
		{
			var value = await categoryRepository.GetByIdAsync(query.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(Category), query.Id);
			}

			return new GetCategoryByIdQueryResult
			{
				Id = value.Id,
				Name = value.Name
			};
		}
	}
}
