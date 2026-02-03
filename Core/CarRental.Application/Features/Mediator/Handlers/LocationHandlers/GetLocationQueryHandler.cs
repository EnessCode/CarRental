using CarRental.Application.Features.Mediator.Queries.LocationQueries;
using CarRental.Application.Features.Mediator.Results.LocationResults;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.LocationHandlers
{
	public class GetLocationQueryHandler(IRepository<Location> repository) : IRequestHandler<GetLocationQuery, List<GetLocationQueryResult>>
	{
		public async Task<List<GetLocationQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
		{
			var values = await repository.GetAllAsync();
			return values.Select(x => new GetLocationQueryResult
			{
				Id = x.Id,
				Name = x.Name
			}).ToList();
		}
	}
}