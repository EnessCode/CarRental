using CarRental.Application.Features.Mediator.Queries.SocialMediaQueries;
using CarRental.Application.Features.Mediator.Results.SocialMediaResults;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
	public class GetSocialMediaQueryHandler(IRepository<SocialMedia> socialMediaRepository) : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
	{
		public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
		{
			var values = await socialMediaRepository.GetAllAsync();
			return values.Select(x => new GetSocialMediaQueryResult
			{
				Id = x.Id,
				Name = x.Name,
				Url = x.Url,
				IconUrl = x.IconUrl
			}).ToList();
		}
	}
}