using CarRental.Application.Features.Mediator.Commands.ReservationCommands;
using CarRental.Application.Interfaces;
using CarRental.Application.Interfaces.CarPricingInterfaces;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.ReservationHandlers
{
	public class CreateReservationCommandHandler(IRepository<Reservation> repository, ICarPricingRepository carPricingRepository) : IRequestHandler<CreateReservationCommand>
	{
		public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
		{
			int totalDays = request.DropOffDate.DayNumber - request.PickUpDate.DayNumber;
			if (totalDays <= 0) totalDays = 1;

			var carPricings = await carPricingRepository.GetCarPricingsByCarId(request.CarId);

			var dailyPrice = carPricings.FirstOrDefault(x => x.PricingId == 1)?.Amount ?? 0;

			decimal calculatedTotalPrice = totalDays * dailyPrice;

			await repository.CreateAsync(new Reservation
			{
				Name = request.Name,
				Surname = request.Surname,
				Email = request.Email,
				Phone = request.Phone,
				CarId = request.CarId,
				AppUserId = request.AppUserId,
				PickUpLocationId = request.PickUpLocationId,
				DropOffLocationId = request.DropOffLocationId,
				Age = request.Age,
				DriverLicenseYear = request.DriverLicenseYear,
				Description = request.Description,
				PickUpDate = request.PickUpDate,
				DropOffDate = request.DropOffDate,
				PickUpTime = request.PickUpTime,
				DropOffTime = request.DropOffTime,
				Status = request.Status,
				TotalPrice = calculatedTotalPrice
			});
		}
	}
}