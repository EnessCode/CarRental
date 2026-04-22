using CarRental.Application.Features.Mediator.Commands.ReservationCommands;
using CarRental.Application.Interfaces;
using CarRental.Application.Interfaces.RentACarProcessInterfaces;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.ReservationHandlers
{
	public class UpdateReservationStatusCommandHandler(IRepository<Reservation> reservationRepository, IRepository<RentACarProcess> processRepository) : IRequestHandler<UpdateReservationStatusCommand>
	{
		public async Task Handle(UpdateReservationStatusCommand request, CancellationToken cancellationToken)
		{
			var reservation = await reservationRepository.GetByIdAsync(request.ReservationId);
			if (reservation == null) throw new Exception("Rezervasyon bulunamadı.");

			reservation.Status = request.NewStatus;
			await reservationRepository.UpdateAsync(reservation);

			if (request.NewStatus == "Onaylandı")
			{
				var process = new RentACarProcess
				{
					ReservationId = reservation.Id,
					CarId = reservation.CarId,
					AppUserId = reservation.AppUserId.Value, 
					PickUpLocationId = reservation.PickUpLocationId,
					DropOffLocationId = reservation.DropOffLocationId,
					PickUpDate = reservation.PickUpDate,
					DropOffDate = reservation.DropOffDate,
					PickUpTime = reservation.PickUpTime,
					DropOffTime = reservation.DropOffTime,
					TotalPrice = reservation.TotalPrice,
					Status = "Araç Teslim Edilmeyi Bekliyor",
					PickUpDescription = "Rezervasyon onaylandı.",
					DropOffDescription = "Henüz teslim alınmadı."
				};

				await processRepository.CreateAsync(process);
			}
		}
	}
}
