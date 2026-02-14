using CarRental.Application.Features.Mediator.Results.BlogResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Queries.BlogQueries
{
	public class GetBlogDetailsQuery(int id) : IRequest<GetBlogDetailsQueryResult>
	{
		public int Id { get; set; } = id;
	}
}
