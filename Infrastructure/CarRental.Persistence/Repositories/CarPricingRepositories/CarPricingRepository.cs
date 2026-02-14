using CarRental.Application.Interfaces.CarPricingInterfaces;
using CarRental.Domain.Entities;
using CarRental.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Persistence.Repositories.CarPricingRepositories
{
	public class CarPricingRepository(CarRentalContext context) : ICarPricingRepository
	{
		public async Task<List<CarPricing>> GetCarPricingWithCars()
		{
			return await context.CarPricings
				.Include(x => x.Car)
				.ThenInclude(y => y.Brand)
				.Include(z => z.Pricing)
				.Where(z => z.PricingId == 3)
				.ToListAsync();
		}
	}
}
