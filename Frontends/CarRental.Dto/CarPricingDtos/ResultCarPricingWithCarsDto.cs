using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Dto.CarPricingDtos
{
	public class ResultCarPricingWithCarsDto
	{
		public int Id { get; set; }
		public string Brand { get; set; }
		public string Model { get; set; }
		public string CoverImageUrl { get; set; }
		public decimal Amount { get; set; }
	}
}
