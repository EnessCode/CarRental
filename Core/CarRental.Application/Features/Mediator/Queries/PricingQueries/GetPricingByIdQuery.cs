using CarRental.Application.Features.Mediator.Results.PricingResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Queries.PricingQueries
{
	public class GetPricingByIdQuery(int id) : IRequest<GetPricingByIdQueryResult>
	{
		public int Id { get; set; } = id;
	}
}