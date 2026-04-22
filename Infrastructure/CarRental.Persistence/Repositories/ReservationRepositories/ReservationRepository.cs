using CarRental.Application.Interfaces.ReservationInterfaces;
using CarRental.Domain.Entities;
using CarRental.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Persistence.Repositories.ReservationRepositories
{
	public class ReservationRepository(CarRentalContext context) : IReservationRepository
	{
		public async Task<List<Reservation>> GetReservationsWithAllDetailsAsync()
		{
			return await context.Reservations
					.Include(x => x.Car)
					.ThenInclude(c => c.Brand)
					.Include(x => x.PickUpLocation) 
					.Include(x => x.DropOffLocation) 
					.Include(x => x.AppUser)
					.OrderByDescending(x => x.Id)
					.ToListAsync();
		}
	}
}