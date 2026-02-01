using CarRental.Application.Common;
using CarRental.Application.Features.CQRS.Commands.CarCommands;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.Features.CQRS.Handlers.CarHandlers
{
	public class RemoveCarCommandHandler(IRepository<Car> carRepository)
	{
		public async Task<RemoveCarCommand> Handle(RemoveCarCommand command)
		{
			var value = await carRepository.GetByIdAsync(command.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(Car), command.Id);
			}

			await carRepository.RemoveAsync(value);

			return command;
		}
	}
}