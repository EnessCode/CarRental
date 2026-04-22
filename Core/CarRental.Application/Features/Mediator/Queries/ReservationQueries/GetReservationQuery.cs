using CarRental.Application.Features.Mediator.Results.ReservationResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Queries.ReservationQueries
{
	public class GetReservationQuery : IRequest<List<GetReservationQueryResult>>
	{
	}
}
