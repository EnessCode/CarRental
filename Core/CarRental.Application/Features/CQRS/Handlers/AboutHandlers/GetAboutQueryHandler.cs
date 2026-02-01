using CarRental.Application.Features.CQRS.Results.AboutResults;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.Features.CQRS.Handlers.AboutHandlers
{
	public class GetAboutQueryHandler(IRepository<About> aboutRepository)
	{
		public async Task<List<GetAboutQueryResult>> Handle()
		{
			var values = await aboutRepository.GetAllAsync();
			return values.Select(x => new GetAboutQueryResult
			{
				Id = x.Id,
				Title = x.Title,
				Description = x.Description,
				ImageUrl = x.ImageUrl
			}).ToList();
		}
	}
}