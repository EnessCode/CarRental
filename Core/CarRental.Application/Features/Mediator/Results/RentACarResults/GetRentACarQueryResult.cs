using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Results.RentACarResults
{
	public class GetRentACarQueryResult
	{
		public int CarId { get; set; }
		public string Brand { get; set; }      
		public string Model { get; set; }      
		public string CoverImageUrl { get; set; }
		public decimal Amount { get; set; }     
		public string Transmission { get; set; } 
		public string Fuel { get; set; }        
		public int Kilometer { get; set; }
		public byte Seat { get; set; }
		public byte Luggage { get; set; }
	}
}
