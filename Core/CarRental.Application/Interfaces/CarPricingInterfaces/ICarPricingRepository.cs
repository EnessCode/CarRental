using CarRental.Application.Features.Mediator.Results.CarPricingResults;
using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Interfaces.CarPricingInterfaces
{
	public interface ICarPricingRepository
	{
		Task<List<CarPricing>> GetCarPricingWithCars();
		Task<List<GetCarPricingWithTimePeriodQueryResult>> GetCarPricingWithTimePeriod();
	}
}
