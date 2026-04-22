using CarRental.Application.Features.Mediator.Queries.RentACarProcessQueries;
using CarRental.Application.Features.Mediator.Results.RentACarProcessResults;
using CarRental.Application.Interfaces;
using CarRental.Application.Interfaces.RentACarProcessInterfaces;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.RentACarProcessHandlers
{
	public class GetRentACarProcessQueryHandler(IRentACarProcessRepository repository) : IRequestHandler<GetRentACarProcessQuery, List<GetRentACarProcessQueryResult>>
	{
		public async Task<List<GetRentACarProcessQueryResult>> Handle(GetRentACarProcessQuery request, CancellationToken cancellationToken)
		{
			var values = await repository.GetRentACarProcessesWithAllDetailsAsync();

			return values.Select(x => new GetRentACarProcessQueryResult
			{
				Id = x.Id,
				CarId=x.CarId,
				ReservationId=x.ReservationId,
				CarBrandAndModel = x.Car?.Brand?.Name + " " + x.Car?.Model,
				CustomerNameSurname = x.AppUser?.Name + " " + x.AppUser?.Surname,
				PickUpLocation = x.PickUpLocation?.Name,
				DropOffLocation = x.DropOffLocation?.Name,
				PickUpDate = x.PickUpDate,
				DropOffDate = x.DropOffDate,
				TotalPrice = x.TotalPrice,
				Status = x.Status
			}).ToList();
		}
	}
}