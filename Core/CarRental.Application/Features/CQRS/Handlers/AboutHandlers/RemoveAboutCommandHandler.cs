using CarRental.Application.Common;
using CarRental.Application.Features.CQRS.Commands.AboutCommands;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.Features.CQRS.Handlers.AboutHandlers
{
	public class RemoveAboutCommandHandler(IRepository<About> aboutRepository)
	{
		public async Task<RemoveAboutCommand> Handle(RemoveAboutCommand command)
		{
			var value = await aboutRepository.GetByIdAsync(command.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(About), command.Id);
			}

			await aboutRepository.RemoveAsync(value);

			return command;
		}
	}
}