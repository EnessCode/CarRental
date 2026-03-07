using CarRental.Application.Interfaces.RentACarInterfaces;
using CarRental.Domain.Entities;
using CarRental.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Persistence.Repositories.RentACarRepositories
{
	public class RentACarRepository(CarRentalContext context) : IRentACarRepository
	{
		public async Task<List<RentACar>> GetByFilterAsync(Expression<Func<RentACar, bool>> filter)
		{
			return await context.RentACars
				.Include(x => x.Car)
				.ThenInclude(y => y.Brand)
				.Include(x => x.Car)
				.ThenInclude(y => y.CarPricings)
				.Where(filter)
				.ToListAsync();
		}
	}
}
