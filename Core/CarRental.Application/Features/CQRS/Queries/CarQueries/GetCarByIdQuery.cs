using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.CQRS.Queries.CarQueries
{
	public class GetCarByIdQuery(int id)
	{
		public int Id { get; set; } = id;
	}
}
