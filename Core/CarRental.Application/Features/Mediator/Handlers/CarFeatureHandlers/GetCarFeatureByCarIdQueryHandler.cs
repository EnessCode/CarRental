using CarRental.Application.Features.Mediator.Queries.CarFeatureQueries;
using CarRental.Application.Features.Mediator.Results.CarFeatureResults;
using CarRental.Application.Interfaces;
using CarRental.Application.Interfaces.CarFeatureInterfaces;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
	public class GetCarFeatureByCarIdQueryHandler(ICarFeatureRepository carFeatureRepository) : IRequestHandler<GetCarFeatureByCarIdQuery, List<GetCarFeatureByCarIdQueryResult>>
	{
		public async Task<List<GetCarFeatureByCarIdQueryResult>> Handle(GetCarFeatureByCarIdQuery request, CancellationToken cancellationToken)
		{
			var values = await carFeatureRepository.GetCarFeaturesByCarId(request.Id);
			return values.Select(x => new GetCarFeatureByCarIdQueryResult
			{
				Id = x.Id,
				CarId= x.CarId,
				FeatureId = x.FeatureId,
				FeatureName = x.Feature.Name,
				Available = x.Available
			}).ToList();
		}
	}
}
