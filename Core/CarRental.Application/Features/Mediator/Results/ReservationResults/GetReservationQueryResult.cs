using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Results.ReservationResults
{
	public class GetReservationQueryResult
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public int CarId { get; set; }
		public string Status { get; set; }
		public DateOnly PickUpDate { get; set; }
		public DateOnly DropOffDate { get; set; }
		public string PickUpLocationName { get; set; } 
		public string DropOffLocationName { get; set; } 
		public string CarModel { get; set; }
		public decimal TotalPrice { get; set; }
	}
}
