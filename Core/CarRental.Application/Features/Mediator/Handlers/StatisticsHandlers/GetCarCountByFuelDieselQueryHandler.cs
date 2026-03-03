using CarRental.Application.Features.Mediator.Queries.StatisticsQueries;
using CarRental.Application.Features.Mediator.Results.StatisticsResults;
using CarRental.Application.Interfaces.StatisticsInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.StatisticsHandlers
{
	public class GetCarCountByFuelDieselQueryHandler(IStatisticsRepository statisticsRepository) : IRequestHandler<GetCarCountByFuelDieselQuery, GetCarCountByFuelDieselQueryResult>
	{
		public async Task<GetCarCountByFuelDieselQueryResult> Handle(GetCarCountByFuelDieselQuery request, CancellationToken cancellationToken)
		{
			var value = await statisticsRepository.GetCarCountByFuelDiesel();
			return new GetCarCountByFuelDieselQueryResult
			{
				CarCountByFuelDiesel = value
			};
		}
	}
}