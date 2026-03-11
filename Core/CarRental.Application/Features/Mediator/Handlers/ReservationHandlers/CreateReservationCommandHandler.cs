using CarRental.Application.Features.Mediator.Commands.ReservationCommands;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.ReservationHandlers
{
	public class CreateReservationCommandHandler(IRepository<Reservation> repository) : IRequestHandler<CreateReservationCommand>
	{
		public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
		{
			await repository.CreateAsync(new Reservation
			{
				Name = request.Name,
				Surname = request.Surname,
				Email = request.Email,
				Phone = request.Phone,
				CarId = request.CarId,
				PickUpLocationId = request.PickUpLocationId,
				DropOffLocationId = request.DropOffLocationId,
				Age = request.Age,
				DriverLicenseYear = request.DriverLicenseYear,
				Description = request.Description,
				Status = request.Status
			});
		}
	}
}
