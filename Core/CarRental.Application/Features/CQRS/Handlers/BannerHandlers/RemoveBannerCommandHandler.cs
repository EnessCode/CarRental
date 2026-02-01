using CarRental.Application.Common;
using CarRental.Application.Features.CQRS.Commands.BannerCommands;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.Features.CQRS.Handlers.BannerHandlers
{
	public class RemoveBannerCommandHandler(IRepository<Banner> bannerRepository)
	{
		public async Task<RemoveBannerCommand> Handle(RemoveBannerCommand command)
		{
			var value = await bannerRepository.GetByIdAsync(command.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(Banner), command.Id);
			}

			await bannerRepository.RemoveAsync(value);

			return command;
		}
	}
}