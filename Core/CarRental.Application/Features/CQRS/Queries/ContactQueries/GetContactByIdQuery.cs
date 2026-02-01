using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.CQRS.Queries.ContactQueries
{
	public class GetContactByIdQuery(int id)
	{
		public int Id { get; } = id;
	}
}
