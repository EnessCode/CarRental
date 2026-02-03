using CarRental.Application.Common;
using CarRental.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
	public class RemoveSocialMediaCommandHandler(IRepository<SocialMedia> socialMediaRepository) : IRequestHandler<RemoveSocialMediaCommand, RemoveSocialMediaCommand>
	{
		public async Task<RemoveSocialMediaCommand> Handle(RemoveSocialMediaCommand request, CancellationToken cancellationToken)
		{
			var value = await socialMediaRepository.GetByIdAsync(request.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(SocialMedia), request.Id);
			}

			await socialMediaRepository.RemoveAsync(value);
			return request;
		}
	}
}