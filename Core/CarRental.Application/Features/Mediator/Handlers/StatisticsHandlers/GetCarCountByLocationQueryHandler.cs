using CarRental.Application.Features.Mediator.Queries.StatisticsQueries;
using CarRental.Application.Features.Mediator.Results.StatisticsResults;
using CarRental.Application.Interfaces;
using CarRental.Application.Interfaces.CarInterfaces;
using CarRental.Application.Interfaces.RentACarInterfaces;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.StatisticsHandlers
{
	public class GetCarCountByLocationQueryHandler(IRentACarRepository repository) : IRequestHandler<GetCarCountByLocationQuery, List<GetCarCountByLocationQueryResult>>
	{
		public async Task<List<GetCarCountByLocationQueryResult>> Handle(GetCarCountByLocationQuery request, CancellationToken cancellationToken)
		{
			var values = await repository.GetRentACarsWithLocation();
			return values.GroupBy(x => x.Location.Name)
							 .Select(y => new GetCarCountByLocationQueryResult
							 {
								 LocationName = y.Key,
								 CarCount = y.Count()
							 }).ToList();
		}
	}
}
