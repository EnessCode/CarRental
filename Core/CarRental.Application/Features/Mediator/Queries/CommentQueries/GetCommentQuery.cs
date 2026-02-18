using CarRental.Application.Features.Mediator.Results.AuthorResults;
using CarRental.Application.Features.Mediator.Results.CommentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Queries.CommentQueries
{
	public class GetCommentQuery : IRequest<List<GetCommentQueryResult>>
	{
	}
}
