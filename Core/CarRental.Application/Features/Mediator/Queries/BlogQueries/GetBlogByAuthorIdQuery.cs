using CarRental.Application.Features.Mediator.Results.BlogResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Queries.BlogQueries
{
	public class GetBlogByAuthorIdQuery(int id) : IRequest<List<GetBlogByAuthorIdQueryResult>>
	{
		public int Id { get; set; } = id;
	}
}