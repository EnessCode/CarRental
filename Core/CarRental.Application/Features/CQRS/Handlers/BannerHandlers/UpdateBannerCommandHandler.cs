using CarRental.Application.Common;
using CarRental.Application.Features.CQRS.Commands.BannerCommands;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.Features.CQRS.Handlers.BannerHandlers
{
	public class UpdateBannerCommandHandler(IRepository<Banner> bannerRepository)
	{
		public async Task<UpdateBannerCommand> Handle(UpdateBannerCommand command)
		{
			var value = await bannerRepository.GetByIdAsync(command.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(Banner), command.Id);
			}

			value.Title = command.Title;
			value.Description = command.Description;
			value.VideoDescription = command.VideoDescription;
			value.VideoUrl = command.VideoUrl;

			await bannerRepository.UpdateAsync(value);
			return command;
		}
	}
}