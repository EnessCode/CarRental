using CarRental.Application.Interfaces.CarInterfaces;
using CarRental.Domain.Entities;
using CarRental.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRental.Persistence.Repositories.CarRepositories
{
	public class CarRepository(CarRentalContext context) : ICarRepository
	{
		public async Task<List<Car>> GetCarsWithBrand()
		{
			var values = await context.Cars.Include(x => x.Brand).ToListAsync();
			return values;
		}
	}
}