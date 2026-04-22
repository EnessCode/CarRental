using CarRental.Application.Interfaces.RentACarProcessInterfaces;
using CarRental.Domain.Entities;
using CarRental.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Persistence.Repositories.RentACarProcessRepositories
{
	public class RentACarProcessRepository(CarRentalContext context) : Repository<RentACarProcess>(context), IRentACarProcessRepository
	{
		public async Task<List<RentACarProcess>> GetRentACarProcessesWithAllDetailsAsync()
		{
			return await context.RentACarProcesses
				.Include(x => x.Car)
				.ThenInclude(c => c.Brand)
				.Include(x => x.AppUser)
				.Include(x => x.PickUpLocation)
				.Include(x => x.DropOffLocation)
				.OrderByDescending(x => x.Id)
				.ToListAsync();
		}
	}
}
