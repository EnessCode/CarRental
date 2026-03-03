using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Interfaces.StatisticsInterfaces
{
	public interface IStatisticsRepository
	{
		Task<int> GetCarCount();
		Task<int> GetLocationCount();
		Task<int> GetAuthorCount();
		Task<int> GetBlogCount();
		Task<int> GetBrandCount();


		Task<int> GetAutomaticCarCount();
		Task<int> GetManualCarCount();


		Task<int> GetCarCountByFuelGasoline();
		Task<int> GetCarCountByFuelDiesel();
		Task<int> GetCarCountByFuelElectric();


		Task<string> GetCarBrandAndModelByMaxRentPrice();
		Task<string> GetCarBrandAndModelByMinRentPrice();
		Task<string> GetBrandNameByMaxCarCount();


		Task<decimal> GetAvgRentPriceForDaily();
		Task<decimal> GetAvgRentPriceForHourly();
		Task<decimal> GetAvgRentPriceForMonthly();
	}
}