using CarRental.Application.Features.CQRS.Results.BannerResults;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.Features.CQRS.Handlers.BannerHandlers
{
	public class GetBannerQueryHandler(IRepository<Banner> bannerRepository)
	{
		public async Task<List<GetBannerQueryResult>> Handle()
		{
			var values = await bannerRepository.GetAllAsync();
			return values.Select(x => new GetBannerQueryResult
			{
				Id = x.Id,
				Title = x.Title,
				Description = x.Description,
				VideoDescription = x.VideoDescription,
				VideoUrl = x.VideoUrl
			}).ToList();
		}
	}
}