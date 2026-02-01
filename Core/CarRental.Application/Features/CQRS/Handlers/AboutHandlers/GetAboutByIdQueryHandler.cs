using CarRental.Application.Common;
using CarRental.Application.Features.CQRS.Queries.AboutQueries;
using CarRental.Application.Features.CQRS.Results.AboutResults;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.Features.CQRS.Handlers.AboutHandlers
{
	public class GetAboutByIdQueryHandler(IRepository<About> aboutRepository)
	{
		public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery query)
		{
			var value = await aboutRepository.GetByIdAsync(query.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(About), query.Id);
			}

			return new GetAboutByIdQueryResult
			{
				Id = value.Id,
				Title = value.Title,
				Description = value.Description,
				ImageUrl = value.ImageUrl
			};
		}
	}
}