using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Dto.RentACarProcessDtos
{
	public class ResultRentACarProcessDto
	{
		public int Id { get; set; }
		public int ReservationId { get; set; }
		public string CustomerFullName { get; set; }
		public int CarId { get; set; }
		public string CarBrandAndModel { get; set; }
		public string CarImage { get; set; }
		public string PickUpLocationName { get; set; }
		public string DropOffLocationName { get; set; }
		public DateOnly PickUpDate { get; set; }
		public DateOnly DropOffDate { get; set; }
		public TimeOnly PickUpTime { get; set; }
		public TimeOnly DropOffTime { get; set; }
		public decimal TotalPrice { get; set; }
		public string Status { get; set; } 
		public string PickUpDescription { get; set; }
		public string DropOffDescription { get; set; }
	}
}