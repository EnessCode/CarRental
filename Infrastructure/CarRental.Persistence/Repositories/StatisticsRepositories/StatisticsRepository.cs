using CarRental.Application.Interfaces.StatisticsInterfaces;
using CarRental.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Persistence.Repositories.StatisticsRepositories
{
	public class StatisticsRepository(CarRentalContext context) : IStatisticsRepository
	{
		public async Task<int> GetAuthorCount()
		{
			return await context.Authors.CountAsync();
		}

		public async Task<int> GetAutomaticCarCount()
		{
			return await context.Cars.CountAsync(x => x.Transmission == "Otomatik");
		}

		public async Task<decimal> GetAvgRentPriceForDaily()
		{
			var prices = await context.CarPricings
				.Where(x => x.Pricing.Name == "Günlük")
				.Select(x => x.Amount)
				.ToListAsync();
			return prices.Average();
		}

		public async Task<decimal> GetAvgRentPriceForHourly()
		{
			var prices = await context.CarPricings
							.Where(x => x.Pricing.Name == "Saatlik")
							.Select(x => x.Amount)
							.ToListAsync();
			return prices.Average();
		}

		public async Task<decimal> GetAvgRentPriceForMonthly()
		{
			var prices = await context.CarPricings
							.Where(x => x.Pricing.Name == "Aylık")
							.Select(x => x.Amount)
							.ToListAsync();
			return prices.Average();
		}

		public async Task<int> GetBlogCount()
		{
			return await context.Blogs.CountAsync();
		}

		public async Task<int> GetBrandCount()
		{
			return await context.Brands.CountAsync();
		}

		public async Task<string> GetBrandNameByMaxCarCount()
		{
			return await context.Cars
				.GroupBy(x => x.BrandId)
				.OrderByDescending(y => y.Count())
				.Select(z => z.FirstOrDefault().Brand.Name)
				.FirstOrDefaultAsync();
		}

		public async Task<string> GetCarBrandAndModelByMaxRentPrice()
		{
			return await context.CarPricings
					.Include(x => x.Car)
					.ThenInclude(y => y.Brand)
					.Where(x => x.Pricing.Name == "Günlük")
					.OrderByDescending(z => z.Amount)
					.Select(k => k.Car.Brand.Name + " - " + k.Car.Model)
					.FirstOrDefaultAsync();
		}

		public async Task<string> GetCarBrandAndModelByMinRentPrice()
		{
			return await context.CarPricings
					.Include(x => x.Car)
					.ThenInclude(y => y.Brand)
					.Where(x => x.Pricing.Name == "Günlük")
					.OrderBy(z => z.Amount)
					.Select(k => k.Car.Brand.Name + " - " + k.Car.Model)
					.FirstOrDefaultAsync();
		}

		public async Task<int> GetCarCount()
		{
			return await context.Cars.CountAsync();
		}

		public async Task<int> GetCarCountByFuelDiesel()
		{
			return await context.Cars.CountAsync(x => x.Fuel == "Dizel");
		}

		public async Task<int> GetCarCountByFuelElectric()
		{
			return await context.Cars.CountAsync(x => x.Fuel == "Elektrik");
		}

		public async Task<int> GetCarCountByFuelGasoline()
		{
			return await context.Cars.CountAsync(x => x.Fuel == "Benzin");
		}

		public async Task<int> GetLocationCount()
		{
			return await context.Locations.CountAsync();
		}

		public async Task<int> GetManualCarCount()
		{
			return await context.Cars.CountAsync(x => x.Transmission == "Manuel");
		}
	}
}