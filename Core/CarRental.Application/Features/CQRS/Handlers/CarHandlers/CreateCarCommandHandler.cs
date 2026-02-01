using CarRental.Application.Features.CQRS.Commands.CarCommands;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.Features.CQRS.Handlers.CarHandlers
{
	public class CreateCarCommandHandler(IRepository<Car> carRepository)
	{
		public async Task<CreateCarCommand> Handle(CreateCarCommand command)
		{
			var car = new Car
			{
				BrandId = command.BrandId,
				Model = command.Model,
				CoverImageUrl = command.CoverImageUrl,
				Kilometer = command.Kilometer,
				Transmission = command.Transmission,
				Seat = command.Seat,
				Luggage = command.Luggage,
				Fuel = command.Fuel,
				BigImageUrl = command.BigImageUrl
			};

			await carRepository.CreateAsync(car);
			return command;
		}
	}
}