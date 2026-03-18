using CarRental.Application.Interfaces.CarFeatureInterfaces;
using CarRental.Domain.Entities;
using CarRental.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Persistence.Repositories.CarFeatureRepositories
{
	public class CarFeatureRepository(CarRentalContext context) : ICarFeatureRepository
	{
		public async Task<CarFeature> ChangeCarFeatureAvailableStatus(int carId, int featureId, bool status)
		{
			var value = await context.CarFeatures.FirstOrDefaultAsync(x => x.CarId == carId && x.FeatureId == featureId);

			if (value != null)
			{
				value.Available = status;
			}
			else
			{
				var newCarFeature = new CarFeature
				{
					CarId = carId,
					FeatureId = featureId,
					Available = status
				};
				await context.CarFeatures.AddAsync(newCarFeature);
				value = newCarFeature;
			}

			await context.SaveChangesAsync();
			return value;
		}

		public async Task<List<CarFeature>> GetCarFeaturesByCarId(int carId)
		{
			var allFeatures = await context.Features.ToListAsync();

			var existingCarFeatures = await context.CarFeatures
				.Where(x => x.CarId == carId)
				.ToListAsync();

			var carFeatureList = new List<CarFeature>();

			foreach (var feature in allFeatures)
			{
				var existing = existingCarFeatures.FirstOrDefault(x => x.FeatureId == feature.Id);

				if (existing != null)
				{
					carFeatureList.Add(existing);
				}
				else
				{
					carFeatureList.Add(new CarFeature
					{
						CarId = carId,
						FeatureId = feature.Id,
						Feature = feature,
						Available = false
					});
				}
			}
			return carFeatureList;
		}
	}
}
