using CarRental.Application.Features.Mediator.Results.CommentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Queries.StatisticsQueries
{
	public class GetCommentsByAuthorIdQuery(int id) : IRequest<List<GetCommentsByAuthorIdQueryResult>>
	{
		public int Id { get; set; } = id;
	}
}