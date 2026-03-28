using CarRental.Application.Interfaces.CarDescriptionInterfaces;
using CarRental.Domain.Entities;
using CarRental.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Persistence.Repositories.CarDescriptionRepositories
{
	public class CarDescriptionRepository(CarRentalContext context) : ICarDescriptionRepository
	{
		public async Task<CarDescription> GetCarDescription(int carId)
		{
			return await context.CarDescriptions
				.Where(x => x.CarId == carId)
				.FirstOrDefaultAsync();
		}
	}
}
