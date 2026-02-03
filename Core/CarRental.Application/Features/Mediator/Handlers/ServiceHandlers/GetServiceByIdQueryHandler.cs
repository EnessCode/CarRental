using CarRental.Application.Common;
using CarRental.Application.Features.Mediator.Queries.ServiceQueries;
using CarRental.Application.Features.Mediator.Results.ServiceResults;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.ServiceHandlers
{
	public class GetServiceByIdQueryHandler(IRepository<Service> serviceRepository) : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
	{
		public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
		{
			var value = await serviceRepository.GetByIdAsync(request.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(Service), request.Id);
			}

			return new GetServiceByIdQueryResult
			{
				Id = value.Id,
				Title = value.Title,
				Description = value.Description,
				IconUrl = value.IconUrl
			};
		}
	}
}