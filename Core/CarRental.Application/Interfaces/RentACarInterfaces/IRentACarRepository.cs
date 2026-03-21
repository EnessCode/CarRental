using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Interfaces.RentACarInterfaces
{
	public interface IRentACarRepository
	{
		Task<List<RentACar>> GetByFilterAsync(Expression<Func<RentACar, bool>> filter);
		Task<List<RentACar>> GetRentACarsWithLocation();
	}
}
