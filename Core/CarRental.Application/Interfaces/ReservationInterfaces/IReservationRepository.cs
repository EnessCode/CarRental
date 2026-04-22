using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Interfaces.ReservationInterfaces
{
	public interface IReservationRepository
	{
		Task<List<Reservation>> GetReservationsWithAllDetailsAsync();
	}
}
