using CarRental.Application.Features.Mediator.Results.CarPricingResults;
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

		public async Task<List<GetCarPricingWithTimePeriodQueryResult>> GetCarPricingWithTimePeriod()
		{
			var query = @"SELECT PivotTable.CarID, 
                         ISNULL(PivotTable.[1], 0) as DailyAmount, 
                         ISNULL(PivotTable.[3], 0) as WeeklyAmount, 
                         ISNULL(PivotTable.[4], 0) as MonthlyAmount,
                         B.[Name] + ' ' + C.Model as CarName, 
                         C.CoverImageUrl, C.Transmission, C.Fuel, C.Seat
                  FROM (SELECT CarID, PricingID, Amount FROM CarPricings) A
                  PIVOT (MAX(Amount) for PricingID IN ([1],[3],[4])) AS PivotTable
                  INNER JOIN Cars C ON C.Id = PivotTable.CarID
                  INNER JOIN Brands B ON B.Id = C.BrandID";

			var list = new List<GetCarPricingWithTimePeriodQueryResult>();

			var connection = context.Database.GetDbConnection();

			using (var command = connection.CreateCommand())
			{
				command.CommandText = query;
				if (connection.State != System.Data.ConnectionState.Open)
					await connection.OpenAsync();

				using (var result = await command.ExecuteReaderAsync())
				{
					while (await result.ReadAsync())
					{
						list.Add(new GetCarPricingWithTimePeriodQueryResult
						{
							CarID = result["CarID"] != DBNull.Value ? Convert.ToInt32(result["CarID"]) : 0,
							CarName = result["CarName"]?.ToString() ?? "Bilinmeyen Araç",
							DailyAmount = result["DailyAmount"] != DBNull.Value ? Convert.ToDecimal(result["DailyAmount"]) : 0,
							WeeklyAmount = result["WeeklyAmount"] != DBNull.Value ? Convert.ToDecimal(result["WeeklyAmount"]) : 0,
							MonthlyAmount = result["MonthlyAmount"] != DBNull.Value ? Convert.ToDecimal(result["MonthlyAmount"]) : 0,
							CoverImageUrl = result["CoverImageUrl"]?.ToString() ?? "",
							Transmission = result["Transmission"]?.ToString() ?? "Bilinmiyor",
							Fuel = result["Fuel"]?.ToString() ?? "Bilinmiyor",
							Seat = result["Seat"] != DBNull.Value ? Convert.ToInt32(result["Seat"]) : 0
						});
					}
				}
			}
			return list;
		}
	}
}
