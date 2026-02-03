using CarRental.Application.Common;
using CarRental.Application.Features.CQRS.Results.AboutResults;
using CarRental.Application.Features.Mediator.Queries.FeatureQueries;
using CarRental.Application.Features.Mediator.Results.FeatureResults;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.FeatureHandlers
{
	public class GetFeatureByIdQueryHandler(IRepository<Feature> featureRepository) : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
	{
		public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
		{
			var value = await featureRepository.GetByIdAsync(request.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(About), request.Id);
			}

			return new GetFeatureByIdQueryResult
			{
				Id = value.Id,
				Name = value.Name
			};
		}
	}
}
