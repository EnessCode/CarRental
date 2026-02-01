using CarRental.Application.Features.CQRS.Commands.AboutCommands;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.Features.CQRS.Handlers.AboutHandlers
{
	public class CreateAboutCommandHandler(IRepository<About> aboutRepository)
	{
		public async Task<CreateAboutCommand> Handle(CreateAboutCommand command)
		{
			var about = new About
			{
				Title = command.Title,
				Description = command.Description,
				ImageUrl = command.ImageUrl
			};

			await aboutRepository.CreateAsync(about);

			return command;
		}
	}
}