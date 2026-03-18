using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Interfaces.CarFeatureInterfaces
{
	public interface ICarFeatureRepository
	{
		Task<List<CarFeature>> GetCarFeaturesByCarId(int carId);
		Task<CarFeature> ChangeCarFeatureAvailableStatus(int carId, int featureId, bool status);
	}
}
