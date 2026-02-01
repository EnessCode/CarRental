using CarRental.Application.Common;
using CarRental.Application.Features.CQRS.Queries.BannerQueries;
using CarRental.Application.Features.CQRS.Results.BannerResults;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.Features.CQRS.Handlers.BannerHandlers
{
	public class GetBannerByIdQueryHandler(IRepository<Banner> bannerRepository)
	{
		public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery query)
		{
			var value = await bannerRepository.GetByIdAsync(query.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(Banner), query.Id);
			}

			return new GetBannerByIdQueryResult
			{
				Id = value.Id,
				Title = value.Title,
				Description = value.Description,
				VideoDescription = value.VideoDescription,
				VideoUrl = value.VideoUrl
			};
		}
	}
}