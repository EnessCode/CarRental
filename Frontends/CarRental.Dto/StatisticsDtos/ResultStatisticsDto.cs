using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Dto.StatisticsDtos
{
	public class ResultStatisticsDto
	{
		public int carCount { get; set; }
		public int locationCount { get; set; }
		public int authorCount { get; set; }
		public int blogCount { get; set; }
		public int brandCount { get; set; }
		public decimal avgRentPriceForDaily { get; set; }
		public decimal avgRentPriceForHourly { get; set; }
		public decimal avgRentPriceForMonthly { get; set; }
		public int automaticCarCount { get; set; }
		public string brandNameByMaxCarCount { get; set; }
		public string carBrandAndModelByMaxRentPrice { get; set; }
		public string carBrandAndModelByMinRentPrice { get; set; }
		public int carCountByFuelGasoline { get; set; }
		public int carCountByFuelDiesel { get; set; }
		public int carCountByFuelElectric { get; set; }
		public int manualCarCount { get; set; }
	}
}
