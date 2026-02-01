using CarRental.Application.Features.CQRS.Commands.BannerCommands;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.Features.CQRS.Handlers.BannerHandlers
{
	public class CreateBannerCommandHandler(IRepository<Banner> bannerRepository)
	{
		public async Task<CreateBannerCommand> Handle(CreateBannerCommand command)
		{
			var banner = new Banner
			{
				Description = command.Description,
				Title = command.Title,
				VideoDescription = command.VideoDescription,
				VideoUrl = command.VideoUrl
			};

			await bannerRepository.CreateAsync(banner);
			return command;
		}
	}
}