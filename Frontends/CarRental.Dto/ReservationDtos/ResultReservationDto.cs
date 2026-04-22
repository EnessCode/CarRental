using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Dto.ReservationDtos
{
	public class ResultReservationDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public int CarId { get; set; }
		public string CarModel { get; set; }
		public string PickUpLocationName { get; set; }
		public string DropOffLocationName { get; set; }
		public int Age { get; set; }
		public int DriverLicenseYear { get; set; }
		public string Description { get; set; }
		public DateOnly PickUpDate { get; set; }
		public DateOnly DropOffDate { get; set; }
		public TimeOnly PickUpTime { get; set; }
		public TimeOnly DropOffTime { get; set; }
		public decimal TotalPrice { get; set; }
		public string Status { get; set; }
	}
}
