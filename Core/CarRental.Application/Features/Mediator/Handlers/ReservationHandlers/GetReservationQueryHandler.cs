using CarRental.Application.Features.Mediator.Queries.ReservationQueries;
using CarRental.Application.Features.Mediator.Results.ReservationResults;
using CarRental.Application.Interfaces;
using CarRental.Application.Interfaces.ReservationInterfaces;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.ReservationHandlers
{
	public class GetReservationQueryHandler(IReservationRepository repository) : IRequestHandler<GetReservationQuery, List<GetReservationQueryResult>>
	{
		public async Task<List<GetReservationQueryResult>> Handle(GetReservationQuery request, CancellationToken cancellationToken)
		{
			var values = await repository.GetReservationsWithAllDetailsAsync();

			return values.Select(x => new GetReservationQueryResult
			{
				Id = x.Id,
				Name = x.Name,
				Surname = x.Surname,
				Email = x.Email,
				Phone = x.Phone,
				PickUpLocationName = x.PickUpLocation?.Name ?? "Belirtilmedi",
				DropOffLocationName = x.DropOffLocation?.Name ?? "Belirtilmedi",
				CarModel = (x.Car?.Brand?.Name ?? "") + " " + (x.Car?.Model ?? ""),
				Status = x.Status,
				TotalPrice = x.TotalPrice,
				PickUpDate = x.PickUpDate,
				DropOffDate = x.DropOffDate
			}).ToList();
		}
	}
}
