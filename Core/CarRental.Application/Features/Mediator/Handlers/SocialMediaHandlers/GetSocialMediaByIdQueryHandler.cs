using CarRental.Application.Common;
using CarRental.Application.Features.Mediator.Queries.SocialMediaQueries;
using CarRental.Application.Features.Mediator.Results.SocialMediaResults;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
	public class GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> socialMediaRepository) : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
	{
		public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
		{
			var value = await socialMediaRepository.GetByIdAsync(request.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(SocialMedia), request.Id);
			}

			return new GetSocialMediaByIdQueryResult
			{
				Id = value.Id,
				Name = value.Name,
				Url = value.Url,
				IconUrl = value.IconUrl
			};
		}
	}
}