using CarRental.Application.Common;
using CarRental.Application.Features.CQRS.Commands.AboutCommands;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.Features.CQRS.Handlers.AboutHandlers
{
	public class UpdateAboutCommandHandler(IRepository<About> aboutRepository)
	{
		public async Task<UpdateAboutCommand> Handle(UpdateAboutCommand command)
		{
			var value = await aboutRepository.GetByIdAsync(command.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(About), command.Id);
			}

			value.Title = command.Title;
			value.Description = command.Description;
			value.ImageUrl = command.ImageUrl;

			await aboutRepository.UpdateAsync(value);
			return command;
		}
	}
}