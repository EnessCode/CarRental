using CarRental.Application.Common;
using CarRental.Application.Features.CQRS.Commands.CarCommands;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.Features.CQRS.Handlers.CarHandlers
{
	public class UpdateCarCommandHandler(IRepository<Car> carRepository)
	{
		public async Task<UpdateCarCommand> Handle(UpdateCarCommand command)
		{
			var values = await carRepository.GetByIdAsync(command.Id);

			if (values == null)
			{
				throw new NotFoundException(nameof(Car), command.Id);
			}

			values.BrandId = command.BrandId;
			values.Model = command.Model;
			values.CoverImageUrl = command.CoverImageUrl;
			values.Kilometer = command.Kilometer;
			values.Transmission = command.Transmission;
			values.Seat = command.Seat;
			values.Luggage = command.Luggage;
			values.Fuel = command.Fuel;
			values.BigImageUrl = command.BigImageUrl;

			await carRepository.UpdateAsync(values);

			return command;
		}
	}
}