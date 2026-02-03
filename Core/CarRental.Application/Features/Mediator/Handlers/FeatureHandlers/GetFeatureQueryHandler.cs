using CarRental.Application.Features.CQRS.Results.BrandResults;
using CarRental.Application.Features.Mediator.Queries.FeatureQueries;
using CarRental.Application.Features.Mediator.Results.FeatureResults;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.FeatureHandlers
{
	public class GetFeatureQueryHandler(IRepository<Feature> featureRepository) : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
	{
		public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
		{
			var values = await featureRepository.GetAllAsync();
			return values.Select(x => new GetFeatureQueryResult
			{
				Id = x.Id,
				Name = x.Name
			}).ToList();
		}
	}
}
