using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Results.CarPricingResults
{
	public class GetCarPricingWithTimePeriodQueryResult
	{
		public int CarID { get; set; }
		public string CarName { get; set; }
		public decimal DailyAmount { get; set; }   
		public decimal WeeklyAmount { get; set; }  
		public decimal MonthlyAmount { get; set; } 
		public string CoverImageUrl { get; set; }
		public string Transmission { get; set; }
		public string Fuel { get; set; }
		public int Seat { get; set; }
	}
}
