using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Entities
{
	public class Location
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<RentACar> RentACars { get; set; }
		public List<Reservation> PickUpReservations { get; set; }
		public List<Reservation> DropOffReservations { get; set; }
	}
}
