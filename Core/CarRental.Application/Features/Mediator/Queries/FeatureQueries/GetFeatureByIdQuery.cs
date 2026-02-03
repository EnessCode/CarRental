using CarRental.Application.Features.Mediator.Results.FeatureResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Queries.FeatureQueries
{
	public class GetFeatureByIdQuery(int id) : IRequest<GetFeatureByIdQueryResult>
	{
		public int Id { get; set; } = id;
	}
}
