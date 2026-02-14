using CarRental.Application.Features.Mediator.Results.TagCloudResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Queries.TagCloudQueries
{
	public class GetTagCloudByBlogIdQuery(int id) : IRequest<List<GetTagCloudByBlogIdQueryResult>>
	{
		public int Id { get; set; } = id;
	}
}
