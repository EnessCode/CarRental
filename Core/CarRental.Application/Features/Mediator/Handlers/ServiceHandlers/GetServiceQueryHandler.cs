using CarRental.Application.Features.Mediator.Queries.ServiceQueries;
using CarRental.Application.Features.Mediator.Results.ServiceResults;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.ServiceHandlers
{
	public class GetServiceQueryHandler(IRepository<Service> serviceRepository) : IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>>
	{
		public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
		{
			var values = await serviceRepository.GetAllAsync();
			return values.Select(x => new GetServiceQueryResult
			{
				Id = x.Id,
				Title = x.Title,
				Description = x.Description,
				IconUrl = x.IconUrl
			}).ToList();
		}
	}
}