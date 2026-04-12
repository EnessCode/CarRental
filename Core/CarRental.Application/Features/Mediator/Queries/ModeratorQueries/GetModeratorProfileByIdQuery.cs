using CarRental.Application.Features.Mediator.Results.ModeratorResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Queries.ModeratorQueries
{
	public class GetModeratorProfileByIdQuery(int id) : IRequest<GetModeratorProfileByIdQueryResult>
	{
		public int Id { get; set; } = id;
	}
}
