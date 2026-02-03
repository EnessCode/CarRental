using CarRental.Application.Common;
using CarRental.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
	public class UpdateSocialMediaCommandHandler(IRepository<SocialMedia> socialMediaRepository) : IRequestHandler<UpdateSocialMediaCommand, UpdateSocialMediaCommand>
	{
		public async Task<UpdateSocialMediaCommand> Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
		{
			var value = await socialMediaRepository.GetByIdAsync(request.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(SocialMedia), request.Id);
			}

			value.Name = request.Name;
			value.Url = request.Url;
			value.IconUrl = request.IconUrl;

			await socialMediaRepository.UpdateAsync(value);
			return request;
		}
	}
}