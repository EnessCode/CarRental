using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Interfaces.CarDescriptionInterfaces
{
	public interface ICarDescriptionRepository
	{
		Task<CarDescription> GetCarDescription(int carId);
	}
}
