using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Results.RentACarProcessResults
{
	public class GetRentACarProcessQueryResult
	{
		public int Id { get; set; }
		public int ReservationId { get; set; }
		public int CarId { get; set; }
		public string CarBrandAndModel { get; set; }
		public string CustomerNameSurname { get; set; }
		public string PickUpLocation { get; set; }
		public string DropOffLocation { get; set; }
		public DateOnly PickUpDate { get; set; }
		public DateOnly DropOffDate { get; set; }
		public decimal TotalPrice { get; set; }
		public string Status { get; set; }
	}
}
