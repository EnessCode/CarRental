using CarRental.Application.Features.Mediator.Results.LocationResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Queries.LocationQueries
{
	public class GetLocationByIdQuery(int id) : IRequest<GetLocationByIdQueryResult>
	{
		public int Id { get; set; } = id;

	}
}
