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
	public class GetCarCountByFuelGasolineQueryHandler(IStatisticsRepository statisticsRepository) : IRequestHandler<GetCarCountByFuelGasolineQuery, GetCarCountByFuelGasolineQueryResult>
	{
		public async Task<GetCarCountByFuelGasolineQueryResult> Handle(GetCarCountByFuelGasolineQuery request, CancellationToken cancellationToken)
		{
			var value = await statisticsRepository.GetCarCountByFuelGasoline();
			return new GetCarCountByFuelGasolineQueryResult
			{
				CarCountByFuelGasoline = value
			};
		}
	}
}