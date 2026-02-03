using CarRental.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
	public class CreateSocialMediaCommandHandler(IRepository<SocialMedia> socialMediaRepository) : IRequestHandler<CreateSocialMediaCommand, CreateSocialMediaCommand>
	{
		public async Task<CreateSocialMediaCommand> Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
		{
			var socialMedia = new SocialMedia
			{
				Name = request.Name,
				Url = request.Url,
				IconUrl = request.IconUrl
			};

			await socialMediaRepository.CreateAsync(socialMedia);
			return request;
		}
	}
}