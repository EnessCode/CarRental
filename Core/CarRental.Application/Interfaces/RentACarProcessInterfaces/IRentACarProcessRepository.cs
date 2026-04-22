using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Interfaces.RentACarProcessInterfaces
{
	public interface IRentACarProcessRepository : IRepository<RentACarProcess>
	{
		Task<List<RentACarProcess>> GetRentACarProcessesWithAllDetailsAsync();
	}
}
